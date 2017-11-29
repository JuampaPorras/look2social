using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using SmartSocial.Data;
using SmartSocial.Desktop.Messaging.Request;
using SmartSocial.Desktop.Messaging.Response;
using SmartSocial.Desktop.Objects;
using SmartSocial.Desktop.Utils;
using System.Threading;
using System.Globalization;

namespace SmartSocial.Desktop.Services
{
    public class ReportService
    {

        enum colDataType
        {
            String = 1,
            Integer = 2,
            Date = 3,
        };

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public ReportDataImportResponse FnProcessColumns(ReportDataImportRequest request)
        {
            var response = new ReportDataImportResponse();
            try
            {
                //declare general vars
                var ds = new DataSet();
                var strConn = "";
                const string quote = "\"";
                var dataColsCount = 0;
                var isChartHeader = true;

                //check if is old or new Excel format
                if (Path.GetExtension(request.ReportTemplateObject.openDialgog.FileName.Trim()) == ".xls")
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 8.0;HDR=Yes;IMEX=1" + quote;
                }
                else
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 12.0 Xml;HDR=Yes;IMEX=1" + quote;
                }

                //declare OleDB data vars
                OleDbConnection objConn;
                DataTable dtSheet;
                DataRow drSchema;
                var strFirstSheetName = "";

                //open connection using Excel file via OleDB to check name of first sheet
                objConn = new OleDbConnection(strConn);
                objConn.Open();
                dtSheet = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "Table" });
                var DataRowArray = dtSheet.Select(null, "TABLE_NAME", DataViewRowState.CurrentRows);
                drSchema = dtSheet.Rows[0];
                strFirstSheetName = drSchema["TABLE_NAME"].ToString();

                //declare OleDB data vars
                var dt = new OleDbDataAdapter("SELECT * FROM [" + strFirstSheetName + "]", strConn);
                dt.TableMappings.Add("Table", "ExcelTable");
                dt.Fill(ds);
                var dv = new DataView(ds.Tables[0]);

                //declare SQL DB context var
                var smartsocialDB = new SmartSocialdbDataContext();
                var newSmartChartRow = new SmartChart();
                var newChartSeriesRow = new ChartSeries();
                var newSeriesValueRow = new SeriesValue();

                //this var is to control where to start as a row position in the Excel file
                var rowConter = 0;
                var rowPosition = 0;
                var ignoreMe = 0;
                DateTime newDateFormat;

                if (dv.Count > 0)
                {
                    //logic to loop into "N" amount of columns and "N" amount of rows per columns
                    for (dataColsCount = 0; dataColsCount <= 5; dataColsCount++)
                    {

                        if (isChartHeader)
                        {
                            //insert header value in SmartChart table 

                            newSmartChartRow.IdSmartReport = request.ReportTemplateObject.SmartReportId;


                            newSmartChartRow.IdChartType = 1;
                            newSmartChartRow.ChartName = "Chart for >> " +
                                                         Path.GetFileName(
                                                             request.ReportTemplateObject.openDialgog.FileName)
                                                             .Substring(0,
                                                                 Path.GetFileName(
                                                                     request.ReportTemplateObject.openDialgog.FileName)
                                                                     .IndexOf("."));
                            newSmartChartRow.FileName =
                                Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName);
                            //smartsocialDB.SmartChart.InsertOnSubmit(newSmartChartRow);
                            //smartsocialDB.SubmitChanges();
                            isChartHeader = false;
                        }

                        //loop inside the dataview in order to save each row/col in the corresponding table in the DB
                        rowPosition = 0;
                        foreach (DataRow drItem in dv.ToTable().Rows)
                        {
                            if (rowConter == 2)
                            {
                                //check there is no null values
                                if (drItem[dataColsCount] != DBNull.Value)
                                {
                                    //insert header value in ChartSeries table
                                    newChartSeriesRow = new ChartSeries();
                                    //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                                    newChartSeriesRow.IdSmartChart = request.ReportTemplateObject.SmartChartId;
                                    newChartSeriesRow.SeriesName = drItem[dataColsCount].ToString();
                                    smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                                    smartsocialDB.SubmitChanges();
                                }
                            }

                            if (rowConter > 2)
                            {
                                //check there is no null values
                                if (drItem[dataColsCount] != DBNull.Value)
                                {
                                    //insert value in SeriesValue table
                                    newSeriesValueRow = new SeriesValue();
                                    newSeriesValueRow.IdChartSeries = newChartSeriesRow.IdChartSeries;
                                    //logic to check the data type of the column the row belongs to
                                    //try to parse for integer
                                    if (int.TryParse(drItem[dataColsCount].ToString(), out ignoreMe))
                                    {
                                        newSeriesValueRow.IdDataType = (int)colDataType.Integer;
                                        newSeriesValueRow.Value = drItem[dataColsCount].ToString();
                                    }
                                    //try to parse for date
                                    else if (DateTime.TryParseExact(drItem[dataColsCount].ToString(),
                                        "ddd MMM dd hh:mm:ss GMT yyyy", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out newDateFormat))
                                    {
                                        newSeriesValueRow.IdDataType = (int)colDataType.Date;
                                        //change date format of each Excel cell
                                        newSeriesValueRow.Value = String.Format("{0:MM/dd/yyyy}",
                                            newDateFormat.AddDays(1));
                                    }
                                    else
                                    {
                                        //if is not integer or date then we will assume is string
                                        newSeriesValueRow.IdDataType = (int)colDataType.String;
                                        newSeriesValueRow.Value = drItem[dataColsCount].ToString();
                                    }
                                    //newSeriesValueRow.IdDataType = 1;
                                    newSeriesValueRow.RowPosition = rowPosition;
                                    smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                                }
                            }
                            rowConter++;
                            rowPosition++;
                        }
                        smartsocialDB.SubmitChanges();
                        rowConter = 0;
                    }
                }

                //close OleDB connection
                objConn.Close();

                //close SQL DB context var
                smartsocialDB.Connection.Close();
                response.Message = "Success";
                response.Acknowledgment = true;

            }

            catch (Exception ex)
            {
                response.Message = "Error: " + ex.Message;
                response.Acknowledgment = false;
            }

            return response;
        }

        public ReportDataImportResponse FnProcessLinear(ReportDataImportRequest request)
        {
            var response = new ReportDataImportResponse();
            try
            {
                //declare general vars
                var ds = new DataSet();
                var strConn = "";
                const string quote = "\"";
                var dataColsCount = 0;
                var isChartHeader = true;

                //check if is old or new Excel format
                if (Path.GetExtension(request.ReportTemplateObject.openDialgog.FileName.Trim()) == ".xls")
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 8.0;HDR=Yes;IMEX=1" + quote;
                }
                else
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 12.0 Xml;HDR=Yes;IMEX=1" + quote;
                }

                //declare OleDB data vars
                OleDbConnection objConn;
                DataTable dtSheet;
                DataRow drSchema;
                var strFirstSheetName = "";

                //open connection using Excel file via OleDB to check name of first sheet
                objConn = new OleDbConnection(strConn);
                objConn.Open();
                dtSheet = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "Table" });
                var DataRowArray = dtSheet.Select(null, "TABLE_NAME", DataViewRowState.CurrentRows);
                drSchema = dtSheet.Rows[0];
                strFirstSheetName = drSchema["TABLE_NAME"].ToString();

                //declare OleDB data vars
                var dt = new OleDbDataAdapter("SELECT * FROM [" + strFirstSheetName + "]", strConn);
                dt.TableMappings.Add("Table", "ExcelTable");
                dt.Fill(ds);
                var dv = new DataView(ds.Tables[0]);

                //declare SQL DB context var
                var smartsocialDB = new SmartSocialdbDataContext();
                var newSmartChartRow = new SmartChart();
                var newChartSeriesRow = new ChartSeries();
                var newSeriesValueRow = new SeriesValue();

                //this var is to control where to start as a row position in the Excel file
                var rowConter = 0;
                var rowPosition = 0;
                var ignoreMe = 0;
                DateTime newDateFormat;

                if (dv.Count > 0)
                {
                    //logic to loop into "N" amount of columns and "N" amount of rows per columns
                    for (dataColsCount = 0; dataColsCount <= 5; dataColsCount++)
                    {

                        if (isChartHeader)
                        {
                            //insert header value in SmartChart table 

                            newSmartChartRow.IdSmartReport = request.ReportTemplateObject.SmartReportId;


                            newSmartChartRow.IdChartType = 1;
                            newSmartChartRow.ChartName = "Chart for >> " +
                                                         Path.GetFileName(
                                                             request.ReportTemplateObject.openDialgog.FileName)
                                                             .Substring(0,
                                                                 Path.GetFileName(
                                                                     request.ReportTemplateObject.openDialgog.FileName)
                                                                     .IndexOf("."));
                            newSmartChartRow.FileName =
                                Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName);
                            //smartsocialDB.SmartChart.InsertOnSubmit(newSmartChartRow);
                            //smartsocialDB.SubmitChanges();
                            isChartHeader = false;
                        }

                        //loop inside the dataview in order to save each row/col in the corresponding table in the DB
                        rowPosition = 0;
                        foreach (DataRow drItem in dv.ToTable().Rows)
                        {
                            if (rowConter == 2)
                            {
                                //check there is no null values
                                if (drItem[dataColsCount] != DBNull.Value)
                                {
                                    //insert header value in ChartSeries table
                                    newChartSeriesRow = new ChartSeries();
                                    //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                                    newChartSeriesRow.IdSmartChart = request.ReportTemplateObject.SmartChartId;
                                    newChartSeriesRow.SeriesName = drItem[dataColsCount].ToString();
                                    smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                                    smartsocialDB.SubmitChanges();
                                }
                            }

                            if (rowConter > 2)
                            {
                                //check there is no null values
                                if (drItem[dataColsCount] != DBNull.Value)
                                {
                                    //insert value in SeriesValue table
                                    newSeriesValueRow = new SeriesValue();
                                    newSeriesValueRow.IdChartSeries = newChartSeriesRow.IdChartSeries;
                                    //logic to check the data type of the column the row belongs to
                                    //try to parse for integer
                                    if (int.TryParse(drItem[dataColsCount].ToString(), out ignoreMe))
                                    {
                                        newSeriesValueRow.IdDataType = (int)colDataType.Integer;
                                        newSeriesValueRow.Value = drItem[dataColsCount].ToString();
                                    }
                                    //try to parse for date
                                    else if (DateTime.TryParseExact(drItem[dataColsCount].ToString(),
                                        "ddd MMM dd hh:mm:ss GMT yyyy", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out newDateFormat))
                                    {
                                        newSeriesValueRow.IdDataType = (int)colDataType.Date;
                                        //change date format of each Excel cell
                                        newSeriesValueRow.Value = String.Format("{0:MM/dd/yyyy}",
                                            newDateFormat.AddDays(1).AddMinutes(1));
                                    }
                                    else
                                    {
                                        //if is not integer or date then we will assume is string
                                        newSeriesValueRow.IdDataType = (int)colDataType.String;
                                        newSeriesValueRow.Value = drItem[dataColsCount].ToString();
                                    }
                                    //newSeriesValueRow.IdDataType = 1;
                                    newSeriesValueRow.RowPosition = rowPosition;
                                    smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                                }
                            }
                            rowConter++;
                            rowPosition++;
                        }
                        smartsocialDB.SubmitChanges();
                        rowConter = 0;
                    }
                }

                //close OleDB connection
                objConn.Close();

                //close SQL DB context var
                smartsocialDB.Connection.Close();
                response.Message = "Success";
                response.Acknowledgment = true;

            }

            catch (Exception ex)
            {
                response.Message = "Error: " + ex.Message;
                response.Acknowledgment = false;
            }
            return response;
        }
        public ReportDataImportResponse FnProcessBestDay(ReportDataImportRequest request)
        {
            var response = new ReportDataImportResponse();
            try
            {
                //declare general vars
                var listOfBestObjects = new List<BestDayObject>();
                var ds = new DataSet();
                var strConn = "";
                const string quote = "\"";
                var dataColsCount = 0;
                var isChartHeader = true;

                //check if is old or new Excel format
                if (Path.GetExtension(request.ReportTemplateObject.openDialgog.FileName.Trim()) == ".xls")
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 8.0;HDR=Yes;IMEX=1" + quote;
                }
                else
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 12.0 Xml;HDR=Yes;IMEX=1" + quote;
                }

                //declare OleDB data vars
                OleDbConnection objConn;
                DataTable dtSheet;
                DataRow drSchema;
                var strFirstSheetName = "";

                //open connection using Excel file via OleDB to check name of first sheet
                objConn = new OleDbConnection(strConn);
                objConn.Open();
                dtSheet = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "Table" });
                var DataRowArray = dtSheet.Select(null, "TABLE_NAME", DataViewRowState.CurrentRows);
                drSchema = dtSheet.Rows[0];
                strFirstSheetName = drSchema["TABLE_NAME"].ToString();

                //declare OleDB data vars
                var dt = new OleDbDataAdapter("SELECT * FROM [" + strFirstSheetName + "]", strConn);
                dt.TableMappings.Add("Table", "ExcelTable");
                dt.Fill(ds);
                var dv = new DataView(ds.Tables[0]);

                //declare SQL DB context var
                var smartsocialDB = new SmartSocialdbDataContext();
                var newSmartChartRow = new SmartChart();
                var newChartSeriesRow = new ChartSeries();
                var newSeriesValueRow = new SeriesValue();

                //this var is to control where to start as a row position in the Excel file
                var rowConter = 0;
                var rowPosition = 0;
                var ignoreMe = 0;
                DateTime newDateFormat;

                if (dv.Count > 0)
                {
                    //logic to loop into "N" amount of columns and "N" amount of rows per columns
                    for (dataColsCount = 0; dataColsCount <= 5; dataColsCount++)
                    {



                        //loop inside the dataview in order to save each row/col in the corresponding table in the DB
                        rowPosition = 0;
                        foreach (DataRow drItem in dv.ToTable().Rows)
                        {
                            var bestDayObject = new BestDayObject();

                            if (rowConter > 2)
                            {
                                //check there is no null values
                                if (drItem[dataColsCount] != DBNull.Value)
                                {

                                    if (int.TryParse(drItem[dataColsCount + 2].ToString(), out ignoreMe))
                                    {
                                        bestDayObject.Count = Convert.ToInt32(drItem[dataColsCount + 2].ToString());
                                    }
                                    //try to parse for date
                                    if (DateTime.TryParseExact(drItem[dataColsCount + 1].ToString(),
                                        "ddd MMM dd hh:mm:ss GMT yyyy", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out newDateFormat))
                                    {
                                        bestDayObject.Time = String.Format("{0:MM/dd/yyyy}",
                                            newDateFormat.AddDays(1));

                                    }


                                }
                            }
                            rowConter++;
                            rowPosition++;
                            listOfBestObjects.Add(bestDayObject);
                        }

                        rowConter = 0;
                    }
                    var bestDay = listOfBestObjects.OrderByDescending(o => o.Count).ToList();

                    newSmartChartRow.IdSmartReport = request.ReportTemplateObject.SmartReportId;
                    newSmartChartRow.IdChartType = 1;
                    newSmartChartRow.ChartName = "Chart for >> " +
                                                 Path.GetFileName(
                                                     request.ReportTemplateObject.openDialgog.FileName)
                                                     .Substring(0,
                                                         Path.GetFileName(
                                                             request.ReportTemplateObject.openDialgog.FileName)
                                                             .IndexOf("."));
                    newSmartChartRow.FileName =
                        Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName);

                    newChartSeriesRow = new ChartSeries
                    {
                        IdSmartChart = request.ReportTemplateObject.SmartChartId,
                        SeriesName = "Term"
                    };
                    smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                    smartsocialDB.SubmitChanges();
                    var idTermSeries = newChartSeriesRow.IdChartSeries;

                    newChartSeriesRow = new ChartSeries
                    {
                        IdSmartChart = request.ReportTemplateObject.SmartChartId,
                        SeriesName = "Count"
                    };

                    smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                    smartsocialDB.SubmitChanges();
                    var idCounterSeries = newChartSeriesRow.IdChartSeries;

                    newSeriesValueRow = new SeriesValue
                    {
                        IdChartSeries = idTermSeries,
                        IdDataType = 3,
                        Value = bestDay.FirstOrDefault().Time,
                        RowPosition = rowPosition
                    };
                    smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                    smartsocialDB.SubmitChanges();

                    newSeriesValueRow = new SeriesValue
                    {
                        IdChartSeries = idCounterSeries,
                        IdDataType = 1,
                        Value = bestDay.FirstOrDefault().Count.ToString(),
                        RowPosition = rowPosition
                    };
                    smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                    smartsocialDB.SubmitChanges();



                }

                //close OleDB connection
                objConn.Close();

                //close SQL DB context var
                smartsocialDB.Connection.Close();
                response.Message = "Success";
                response.Acknowledgment = true;

            }

            catch (Exception ex)
            {
                response.Message = "Error: " + ex.Message;
                response.Acknowledgment = false;
            }
            return response;
        }

        public ReportDataImportResponse FnProcessStackedColumns(ReportDataImportRequest request)
        {
            var response = new ReportDataImportResponse();
            try
            {
                //declare general vars
                var ds = new DataSet();
                var strConn = "";
                const string quote = "\"";
                var dataColsCount = 0;
                var isChartHeader = true;

                //check if is old or new Excel format
                if (Path.GetExtension(request.ReportTemplateObject.openDialgog.FileName.Trim()) == ".xls")
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 8.0;HDR=Yes;IMEX=1" + quote;
                }
                else
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 12.0 Xml;HDR=Yes;IMEX=1" + quote;
                }

                //declare OleDB data vars
                OleDbConnection objConn;
                DataTable dtSheet;
                DataRow drSchema;
                var strFirstSheetName = "";

                //open connection using Excel file via OleDB to check name of first sheet
                objConn = new OleDbConnection(strConn);
                objConn.Open();
                dtSheet = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "Table" });
                var DataRowArray = dtSheet.Select(null, "TABLE_NAME", DataViewRowState.CurrentRows);
                drSchema = dtSheet.Rows[0];
                strFirstSheetName = drSchema["TABLE_NAME"].ToString();

                //declare OleDB data vars
                var dt = new OleDbDataAdapter("SELECT * FROM [" + strFirstSheetName + "]", strConn);
                dt.TableMappings.Add("Table", "ExcelTable");
                dt.Fill(ds);
                var dv = new DataView(ds.Tables[0]);

                //declare SQL DB context var
                var smartsocialDB = new SmartSocialdbDataContext();
                var newSmartChartRow = new SmartChart();
                var newChartSeriesRow = new ChartSeries();
                var newSeriesValueRow = new SeriesValue();

                //this var is to control where to start as a row position in the Excel file
                var rowConter = 0;
                var rowPosition = 0;
                var ignoreMe = 0;
                DateTime newDateFormat;

                if (dv.Count > 0)
                {
                    //logic to loop into "N" amount of columns and "N" amount of rows per columns
                    for (dataColsCount = 0; dataColsCount <= 5; dataColsCount++)
                    {

                        if (isChartHeader)
                        {
                            //insert header value in SmartChart table 

                            newSmartChartRow.IdSmartReport = request.ReportTemplateObject.SmartReportId;


                            newSmartChartRow.IdChartType = 1;
                            newSmartChartRow.ChartName = "Chart for >> " +
                                                         Path.GetFileName(
                                                             request.ReportTemplateObject.openDialgog.FileName)
                                                             .Substring(0,
                                                                 Path.GetFileName(
                                                                     request.ReportTemplateObject.openDialgog.FileName)
                                                                     .IndexOf("."));
                            newSmartChartRow.FileName =
                                Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName);
                            //smartsocialDB.SmartChart.InsertOnSubmit(newSmartChartRow);
                            //smartsocialDB.SubmitChanges();
                            isChartHeader = false;
                        }

                        //loop inside the dataview in order to save each row/col in the corresponding table in the DB
                        rowPosition = 0;
                        foreach (DataRow drItem in dv.ToTable().Rows)
                        {
                            if (rowConter == 2)
                            {
                                //check there is no null values
                                if (drItem[dataColsCount] != DBNull.Value)
                                {
                                    //insert header value in ChartSeries table
                                    newChartSeriesRow = new ChartSeries();
                                    //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                                    newChartSeriesRow.IdSmartChart = request.ReportTemplateObject.SmartChartId;
                                    newChartSeriesRow.SeriesName = drItem[dataColsCount].ToString();
                                    smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                                    smartsocialDB.SubmitChanges();
                                }
                            }

                            if (rowConter > 2)
                            {
                                //check there is no null values
                                if (drItem[dataColsCount] != DBNull.Value)
                                {
                                    //insert value in SeriesValue table
                                    newSeriesValueRow = new SeriesValue();
                                    newSeriesValueRow.IdChartSeries = newChartSeriesRow.IdChartSeries;
                                    //logic to check the data type of the column the row belongs to
                                    //try to parse for integer
                                    if (int.TryParse(drItem[dataColsCount].ToString(), out ignoreMe))
                                    {
                                        newSeriesValueRow.IdDataType = (int)colDataType.Integer;
                                        newSeriesValueRow.Value = drItem[dataColsCount].ToString();
                                    }
                                    //try to parse for date
                                    else if (DateTime.TryParseExact(drItem[dataColsCount].ToString(),
                                        "ddd MMM dd hh:mm:ss GMT yyyy", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out newDateFormat))
                                    {
                                        newSeriesValueRow.IdDataType = (int)colDataType.Date;
                                        //change date format of each Excel cell
                                        newSeriesValueRow.Value = String.Format("{0:MM/dd/yyyy}",
                                            newDateFormat.AddDays(1));
                                    }
                                    else
                                    {
                                        //if is not integer or date then we will assume is string
                                        newSeriesValueRow.IdDataType = (int)colDataType.String;
                                        newSeriesValueRow.Value = drItem[dataColsCount].ToString();
                                    }
                                    //newSeriesValueRow.IdDataType = 1;
                                    newSeriesValueRow.RowPosition = rowPosition;
                                    smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                                }
                            }
                            rowConter++;
                            rowPosition++;
                        }
                        smartsocialDB.SubmitChanges();
                        rowConter = 0;
                    }
                }

                //close OleDB connection
                objConn.Close();

                //close SQL DB context var
                smartsocialDB.Connection.Close();
                response.Message = "Success";
                response.Acknowledgment = true;

            }

            catch (Exception ex)
            {
                response.Message = "Error: " + ex.Message;
                response.Acknowledgment = false;
            }
            return response;
        }

        public ReportDataImportResponse FnProcessTreeMap(ReportDataImportRequest request)
        {
            var response = new ReportDataImportResponse();
            try
            {


                //declare SQL DB context var
                var smartsocialDb = new SmartSocialdbDataContext();
                var newSmartChartRow = new SmartChart();
                var newChartSeriesRow = new ChartSeries();
                var newSeriesValueRow = new SeriesValue();

                //declare general vars
                var isChartHeader = true;
                var rowPosition = 0;
                var groupCounter = 0;
                var col1 = 0;
                var col2 = 0;
                var col3 = 0;
                var col4 = 0;

                var sReader = new StreamReader(request.ReportTemplateObject.openDialgog.FileName);
                var jReader = new JsonTextReader(sReader);
                var jObject = (JObject)JToken.ReadFrom(jReader);
                foreach (var theItem in jObject["groups"])
                {
                    //For each Root Node
                    var ReturnedNode = new TreeNode(theItem["label"].ToString() + " - " + theItem["weight"].ToString());

                    groupCounter = groupCounter + 100000;

                    if (isChartHeader)
                    {
                        //insert header value in SmartChart table 

                        newSmartChartRow.IdSmartReport = request.ReportTemplateObject.SmartReportId;

                        newSmartChartRow.IdChartType = 1;
                        newSmartChartRow.ChartName = "Chart for >> " +
                                                     Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName)
                                                         .Substring(0,
                                                             Path.GetFileName(
                                                                 request.ReportTemplateObject.openDialgog.FileName)
                                                                 .IndexOf("."));
                        newSmartChartRow.FileName = Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName);
                        //smartsocialDB.SmartChart.InsertOnSubmit(newSmartChartRow);
                        //smartsocialDB.SubmitChanges();
                        isChartHeader = false;

                        //insert header value in ChartSeries table col1
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Parent Topic"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;

                        smartsocialDb.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDb.SubmitChanges();
                        col1 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col2
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Topic"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        smartsocialDb.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDb.SubmitChanges();
                        col2 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col3
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Weight"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        smartsocialDb.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDb.SubmitChanges();
                        col3 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col4
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Parent Weight"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        smartsocialDb.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDb.SubmitChanges();
                        col4 = newChartSeriesRow.IdChartSeries;

                    }

                    if (theItem["groups"] != null) //Nodes that don't have children return NULL for Groups
                    {
                        //For each SubItem
                        //Insert rows for Parent Topic Col
                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["groups"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue
                            {
                                IdChartSeries = col1,
                                Value = theItem["label"].ToString(),
                                RowPosition = rowPosition
                            };
                            smartsocialDb.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        //Insert rows for Topic Col
                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["groups"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue
                            {
                                IdChartSeries = col2,
                                Value = theSubItem["label"].ToString(),
                                RowPosition = rowPosition
                            };
                            smartsocialDb.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        //Insert rows for Child Weight Col
                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["groups"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue
                            {
                                IdChartSeries = col3,
                                Value = theSubItem["weight"].ToString(),
                                RowPosition = rowPosition
                            };
                            smartsocialDb.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        //Insert rows for Parent Weight Col
                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["groups"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue
                            {
                                IdChartSeries = col4,
                                Value = theItem["weight"].ToString(),
                                RowPosition = rowPosition
                            };
                            smartsocialDb.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        smartsocialDb.SubmitChanges();
                    }

                }


                //close SQL DB context var
                smartsocialDb.Connection.Close();

                response.Message = "Success";
                response.Acknowledgment = true;

            }

            catch (Exception ex)
            {
                response.Message = "Error: " + ex.Message;
                response.Acknowledgment = false;
            }

            return response;
        }

        public ReportDataImportResponse FnProcessWorldCloud(ReportDataImportRequest request)
        {
            var response = new ReportDataImportResponse();
            try
            {

                //declare SQL DB context var
                var smartsocialDB = new SmartSocialdbDataContext();
                var newSmartChartRow = new SmartChart();
                var newChartSeriesRow = new ChartSeries();
                var newSeriesValueRow = new SeriesValue();

                //declare general vars
                var isChartHeader = true;
                var rowPosition = 0;
                var col1 = 0;
                var col2 = 0;

                var sReader = new StreamReader(request.ReportTemplateObject.openDialgog.FileName);
                var jReader = new JsonTextReader(sReader);
                var jObject = (JObject)JToken.ReadFrom(jReader);
                foreach (var theItem in jObject["data"])
                {
                    //For each Root Node
                    var ReturnedNode = new TreeNode(theItem["word"].ToString() + " - " + theItem["count"].ToString());

                    if (isChartHeader)
                    {

                        newSmartChartRow.IdSmartReport = request.ReportTemplateObject.SmartReportId;
                        newSmartChartRow.IdChartType = 1;
                        newSmartChartRow.ChartName = "Chart for >> " +
                                                     Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName)
                                                         .Substring(0,
                                                             Path.GetFileName(
                                                                 request.ReportTemplateObject.openDialgog.FileName)
                                                                 .IndexOf("."));
                        newSmartChartRow.FileName = Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName);
                        //smartsocialDB.SmartChart.InsertOnSubmit(newSmartChartRow);
                        //smartsocialDB.SubmitChanges();
                        isChartHeader = false;

                        //insert header value in ChartSeries table col1
                        newChartSeriesRow = new ChartSeries();
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        newChartSeriesRow.IdSmartChart = request.ReportTemplateObject.SmartChartId;

                        newChartSeriesRow.SeriesName = "Term";
                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col1 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col2
                        newChartSeriesRow = new ChartSeries();
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;

                        newChartSeriesRow.IdSmartChart = request.ReportTemplateObject.SmartChartId;
                        newChartSeriesRow.SeriesName = "Count";
                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col2 = newChartSeriesRow.IdChartSeries;

                    }

                    //insert value in SeriesValue table
                    newSeriesValueRow = new SeriesValue();
                    newSeriesValueRow.IdChartSeries = col1;
                    newSeriesValueRow.Value = theItem["word"].ToString();
                    newSeriesValueRow.RowPosition = rowPosition;
                    smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);

                    //insert value in SeriesValue table
                    newSeriesValueRow = new SeriesValue();
                    newSeriesValueRow.IdChartSeries = col2;
                    newSeriesValueRow.Value = theItem["count"].ToString();
                    newSeriesValueRow.RowPosition = rowPosition;
                    smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);

                    rowPosition++;

                    smartsocialDB.SubmitChanges();

                }

                //close SQL DB context var
                smartsocialDB.Connection.Close();

                response.Message = "Success";
                response.Acknowledgment = true;

            }

            catch (Exception ex)
            {
                response.Message = "Error: " + ex.Message;
                response.Acknowledgment = false;
            }

            return response;
        }

        public ReportDataImportResponse FnProcessPie(ReportDataImportRequest request)
        {
            var response = new ReportDataImportResponse();
            try
            {
                //declare general vars
                var ds = new DataSet();
                var strConn = "";
                const string quote = "\"";
                var dataColsCount = 0;
                var isChartHeader = true;

                //check if is old or new Excel format
                if (Path.GetExtension(request.ReportTemplateObject.openDialgog.FileName.Trim()) == ".xls")
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 8.0;HDR=Yes;IMEX=1" + quote;
                }
                else
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 12.0 Xml;HDR=Yes;IMEX=1" + quote;
                }

                //declare OleDB data vars
                OleDbConnection objConn;
                DataTable dtSheet;
                DataRow drSchema;
                var strFirstSheetName = "";

                //open connection using Excel file via OleDB to check name of first sheet
                objConn = new OleDbConnection(strConn);
                objConn.Open();
                dtSheet = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "Table" });
                var DataRowArray = dtSheet.Select(null, "TABLE_NAME", DataViewRowState.CurrentRows);
                drSchema = dtSheet.Rows[0];
                strFirstSheetName = drSchema["TABLE_NAME"].ToString();

                //declare OleDB data vars
                var dt = new OleDbDataAdapter("SELECT * FROM [" + strFirstSheetName + "]", strConn);
                dt.TableMappings.Add("Table", "ExcelTable");
                dt.Fill(ds);
                var dv = new DataView(ds.Tables[0]);

                //declare SQL DB context var
                var smartsocialDB = new SmartSocialdbDataContext();
                var newSmartChartRow = new SmartChart();
                var newChartSeriesRow = new ChartSeries();
                var newSeriesValueRow = new SeriesValue();

                //this var is to control where to start as a row position in the Excel file
                var rowConter = 0;
                var rowPosition = 0;
                var ignoreMe = 0;
                DateTime newDateFormat;

                if (dv.Count > 0)
                {
                    //logic to loop into "N" amount of columns and "N" amount of rows per columns
                    for (dataColsCount = 0; dataColsCount <= 5; dataColsCount++)
                    {

                        if (isChartHeader)
                        {
                            //insert header value in SmartChart table 

                            newSmartChartRow.IdSmartReport = request.ReportTemplateObject.SmartReportId;


                            newSmartChartRow.IdChartType = 1;
                            newSmartChartRow.ChartName = "Chart for >> " +
                                                         Path.GetFileName(
                                                             request.ReportTemplateObject.openDialgog.FileName)
                                                             .Substring(0,
                                                                 Path.GetFileName(
                                                                     request.ReportTemplateObject.openDialgog.FileName)
                                                                     .IndexOf("."));
                            newSmartChartRow.FileName =
                                Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName);
                            //smartsocialDB.SmartChart.InsertOnSubmit(newSmartChartRow);
                            //smartsocialDB.SubmitChanges();
                            isChartHeader = false;
                        }

                        //loop inside the dataview in order to save each row/col in the corresponding table in the DB
                        rowPosition = 0;
                        foreach (DataRow drItem in dv.ToTable().Rows)
                        {
                            if (rowConter == 2)
                            {
                                //check there is no null values
                                if (drItem[dataColsCount] != DBNull.Value)
                                {
                                    //insert header value in ChartSeries table
                                    newChartSeriesRow = new ChartSeries();
                                    //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                                    newChartSeriesRow.IdSmartChart = request.ReportTemplateObject.SmartChartId;
                                    newChartSeriesRow.SeriesName = drItem[dataColsCount].ToString();
                                    smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                                    smartsocialDB.SubmitChanges();
                                }
                            }

                            if (rowConter > 2)
                            {
                                //check there is no null values
                                if (drItem[dataColsCount] != DBNull.Value)
                                {
                                    //insert value in SeriesValue table
                                    newSeriesValueRow = new SeriesValue();
                                    newSeriesValueRow.IdChartSeries = newChartSeriesRow.IdChartSeries;
                                    //logic to check the data type of the column the row belongs to
                                    //try to parse for integer
                                    if (int.TryParse(drItem[dataColsCount].ToString(), out ignoreMe))
                                    {
                                        newSeriesValueRow.IdDataType = (int)colDataType.Integer;
                                        newSeriesValueRow.Value = drItem[dataColsCount].ToString();
                                    }
                                    //try to parse for date
                                    else if (DateTime.TryParseExact(drItem[dataColsCount].ToString(),
                                        "ddd MMM dd hh:mm:ss GMT yyyy", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out newDateFormat))
                                    {
                                        newSeriesValueRow.IdDataType = (int)colDataType.Date;
                                        //change date format of each Excel cell
                                        newSeriesValueRow.Value = String.Format("{0:MM/dd/yyyy}",
                                            newDateFormat.AddDays(1));
                                    }
                                    else
                                    {
                                        //if is not integer or date then we will assume is string
                                        newSeriesValueRow.IdDataType = (int)colDataType.String;
                                        newSeriesValueRow.Value = drItem[dataColsCount].ToString();
                                    }
                                    //newSeriesValueRow.IdDataType = 1;
                                    newSeriesValueRow.RowPosition = rowPosition;
                                    smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                                }
                            }
                            rowConter++;
                            rowPosition++;
                        }
                        smartsocialDB.SubmitChanges();
                        rowConter = 0;
                    }
                }

                //close OleDB connection
                objConn.Close();

                //close SQL DB context var
                smartsocialDB.Connection.Close();
                response.Message = "Success";
                response.Acknowledgment = true;

            }

            catch (Exception ex)
            {
                response.Message = "Error: " + ex.Message;
                response.Acknowledgment = false;
            }

            return response;
        }

        public ReportDataImportResponse FnProcessMostProfilicUsers(ReportDataImportRequest request)
        {
            var response = new ReportDataImportResponse();
            try
            {

                //declare SQL DB context var
                var smartsocialDB = new SmartSocialdbDataContext();
                var newSmartChartRow = new SmartChart();
                var newChartSeriesRow = new ChartSeries();
                var newSeriesValueRow = new SeriesValue();

                //declare general vars
                var isChartHeader = true;
                var rowPosition = 0;
                var groupCounter = 0;
                var col1 = 0;
                var col2 = 0;
                var col3 = 0;
                var col4 = 0;
                var col5 = 0;
                var col6 = 0;
                var col7 = 0;
                var col8 = 0;
                var col9 = 0;
                var col10 = 0;
                var col11 = 0;

                var rowPos = 0;

                var sReader = new StreamReader(request.ReportTemplateObject.openDialgog.FileName);
                var jReader = new JsonTextReader(sReader);
                var jObject = (JObject)JToken.ReadFrom(jReader);
                foreach (var theItem in jObject["data"])
                {
                    //For each Root Node
                    var ReturnedNode = new TreeNode("Row >> " + rowPos.ToString());

                    groupCounter = groupCounter + 100000;

                    if (isChartHeader)
                    {

                        newSmartChartRow.IdSmartReport = request.ReportTemplateObject.SmartReportId;

                        newSmartChartRow.IdChartType = 1;
                        newSmartChartRow.ChartName = "Chart for >> " +
                                                     Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName)
                                                         .Substring(0,
                                                             Path.GetFileName(
                                                                 request.ReportTemplateObject.openDialgog.FileName)
                                                                 .IndexOf("."));
                        newSmartChartRow.FileName = Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName);
                        //smartsocialDB.SmartChart.InsertOnSubmit(newSmartChartRow);
                        //smartsocialDB.SubmitChanges();
                        isChartHeader = false;

                        //insert header value in ChartSeries table col1
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Social Network"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;


                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col1 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col2
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Screen Name"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;


                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col2 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col3
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Bio"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col3 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col4
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Statusses"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col4 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col5
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Reach"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col5 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col6
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Url"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col6 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col7
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Followers"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col7 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col8
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Following"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col8 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col9
                        newChartSeriesRow = new ChartSeries
                        {
                            IdSmartChart = request.ReportTemplateObject.SmartChartId,
                            SeriesName = "Fullname"
                        };
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col9 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col9
                        newChartSeriesRow = new ChartSeries();
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        newChartSeriesRow.IdSmartChart = request.ReportTemplateObject.SmartChartId;
                        newChartSeriesRow.SeriesName = "profileImageUrl";
                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col10 = newChartSeriesRow.IdChartSeries;

                        //insert header value in ChartSeries table col9
                        newChartSeriesRow = new ChartSeries();
                        //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                        newChartSeriesRow.IdSmartChart = request.ReportTemplateObject.SmartChartId;
                        newChartSeriesRow.SeriesName = "totalPosts";
                        smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                        smartsocialDB.SubmitChanges();
                        col11 = newChartSeriesRow.IdChartSeries;



                    }

                    if (theItem["socialProfiles"] != null) //Nodes that don't have children return NULL for Groups
                    {
                        //For each SubItem
                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["socialProfiles"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue();
                            newSeriesValueRow.IdChartSeries = col1;
                            newSeriesValueRow.Value = theSubItem["type"].ToString();
                            newSeriesValueRow.RowPosition = rowPosition;
                            smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["socialProfiles"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue();
                            newSeriesValueRow.IdChartSeries = col2;
                            newSeriesValueRow.Value = theSubItem["username"].ToString();
                            newSeriesValueRow.RowPosition = rowPosition;
                            smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["socialProfiles"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue { IdChartSeries = col3 };
                            try
                            {
                                newSeriesValueRow.Value = theSubItem["bio"].ToString();
                            }
                            catch (Exception x)
                            {
                                newSeriesValueRow.Value = "";
                            }
                            newSeriesValueRow.RowPosition = rowPosition;
                            smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["socialProfiles"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue
                            {
                                IdChartSeries = col4,
                                Value = theSubItem["statusCount"].ToString(),
                                RowPosition = rowPosition
                            };
                            smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["socialProfiles"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue
                            {
                                IdChartSeries = col5,
                                Value = theSubItem["reach"].ToString(),
                                RowPosition = rowPosition
                            };
                            smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["socialProfiles"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue { IdChartSeries = col6 };
                            try
                            {
                                newSeriesValueRow.Value = theSubItem["url"].ToString();
                            }
                            catch (Exception x)
                            {
                                newSeriesValueRow.Value = "";
                            }
                            newSeriesValueRow.RowPosition = rowPosition;
                            smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["socialProfiles"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue
                            {
                                IdChartSeries = col7,
                                Value = theSubItem["followers"].ToString(),
                                RowPosition = rowPosition
                            };
                            smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["socialProfiles"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue
                            {
                                IdChartSeries = col8,
                                Value = theSubItem["following"].ToString(),
                                RowPosition = rowPosition
                            };
                            smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }

                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["contactInfo"])
                        {
                            if (theSubItem.Path == "data[" + rowPos.ToString() + "].contactInfo.fullName")
                            {
                                //insert value in SeriesValue table
                                newSeriesValueRow = new SeriesValue
                                {
                                    IdChartSeries = col9,
                                    Value = theSubItem.First.ToString(),
                                    RowPosition = rowPosition
                                };
                                smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                                rowPosition++;
                            }
                        }

                        rowPosition = 1 * groupCounter;
                        foreach (var theSubItem in theItem["socialProfiles"])
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue { IdChartSeries = col10 };
                            try
                            {
                                newSeriesValueRow.Value = theSubItem["profileImageUrl"].ToString();
                            }
                            catch (Exception x)
                            {
                                newSeriesValueRow.Value = "";
                            }
                            newSeriesValueRow.RowPosition = rowPosition;
                            smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                            rowPosition++;
                        }


                        if (theItem["totalPosts"] != null)
                        {
                            //insert value in SeriesValue table
                            newSeriesValueRow = new SeriesValue { IdChartSeries = col11 };
                            try
                            {
                                newSeriesValueRow.Value = theItem["totalPosts"].ToString();
                            }
                            catch (Exception ex)
                            {
                                newSeriesValueRow.Value = "";
                            }
                            newSeriesValueRow.RowPosition = rowPosition;
                            smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                        }

                        smartsocialDB.SubmitChanges();
                        rowPos++;

                    }

                }

                //close SQL DB context var
                smartsocialDB.Connection.Close();
                response.Message = "Success";
                response.Acknowledgment = true;

            }


            catch (Exception ex)
            {
                response.Message = "Error: " + ex.Message;
                response.Acknowledgment = false;
            }
            return response;
        }

        public ReportDataImportResponse FnProcessLocationAnalysis(ReportDataImportRequest request)
        {
            var response = new ReportDataImportResponse();
            try
            {
                //declare general vars
                var ds = new DataSet();
                var strConn = "";
                const string quote = "\"";
                var dataColsCount = 0;
                var isChartHeader = true;

                //check if is old or new Excel format
                if (Path.GetExtension(request.ReportTemplateObject.openDialgog.FileName.Trim()) == ".xls")
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 8.0;HDR=Yes;IMEX=1" + quote;
                }
                else
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                              request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" +
                              quote + "Excel 12.0 Xml;HDR=Yes;IMEX=1" + quote;
                }

                //declare OleDB data vars
                OleDbConnection objConn;
                DataTable dtSheet;
                DataRow drSchema;
                var strFirstSheetName = "";

                //open connection using Excel file via OleDB to check name of first sheet
                objConn = new OleDbConnection(strConn);
                objConn.Open();
                dtSheet = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "Table" });
                var DataRowArray = dtSheet.Select(null, "TABLE_NAME", DataViewRowState.CurrentRows);
                drSchema = dtSheet.Rows[0];
                strFirstSheetName = drSchema["TABLE_NAME"].ToString();

                //declare OleDB data vars
                var dt = new OleDbDataAdapter("SELECT * FROM [" + strFirstSheetName + "]", strConn);
                dt.TableMappings.Add("Table", "ExcelTable");
                dt.Fill(ds);
                var dv = new DataView(ds.Tables[0]);

                //declare SQL DB context var
                var smartsocialDB = new SmartSocialdbDataContext();
                var newSmartChartRow = new SmartChart();
                var newChartSeriesRow = new ChartSeries();
                var newSeriesValueRow = new SeriesValue();

                //this var is to control where to start as a row position in the Excel file
                var rowConter = 0;
                var rowPosition = 0;
                var ignoreMe = 0;
                DateTime newDateFormat;

                if (dv.Count > 0)
                {
                    //logic to loop into "N" amount of columns and "N" amount of rows per columns
                    for (dataColsCount = 0; dataColsCount <= 5; dataColsCount++)
                    {

                        if (isChartHeader)
                        {
                            //insert header value in SmartChart table 

                            newSmartChartRow.IdSmartReport = request.ReportTemplateObject.SmartReportId;


                            newSmartChartRow.IdChartType = 1;
                            newSmartChartRow.ChartName = "Chart for >> " +
                                                         Path.GetFileName(
                                                             request.ReportTemplateObject.openDialgog.FileName)
                                                             .Substring(0,
                                                                 Path.GetFileName(
                                                                     request.ReportTemplateObject.openDialgog.FileName)
                                                                     .IndexOf("."));
                            newSmartChartRow.FileName =
                                Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName);
                            //smartsocialDB.SmartChart.InsertOnSubmit(newSmartChartRow);
                            //smartsocialDB.SubmitChanges();
                            isChartHeader = false;
                        }

                        //loop inside the dataview in order to save each row/col in the corresponding table in the DB
                        rowPosition = 0;
                        foreach (DataRow drItem in dv.ToTable().Rows)
                        {
                            if (rowConter == 2)
                            {
                                //check there is no null values
                                if (drItem[dataColsCount] != DBNull.Value)
                                {
                                    //insert header value in ChartSeries table
                                    newChartSeriesRow = new ChartSeries();
                                    //newChartSeriesRow.IdSmartChart = newSmartChartRow.IdSmartChart;
                                    newChartSeriesRow.IdSmartChart = request.ReportTemplateObject.SmartChartId;
                                    newChartSeriesRow.SeriesName = drItem[dataColsCount].ToString();
                                    smartsocialDB.ChartSeries.InsertOnSubmit(newChartSeriesRow);
                                    smartsocialDB.SubmitChanges();
                                }
                            }

                            if (rowConter > 2)
                            {
                                //check there is no null values
                                if (drItem[dataColsCount] != DBNull.Value)
                                {
                                    //insert value in SeriesValue table
                                    newSeriesValueRow = new SeriesValue();
                                    newSeriesValueRow.IdChartSeries = newChartSeriesRow.IdChartSeries;
                                    //logic to check the data type of the column the row belongs to
                                    //try to parse for integer
                                    if (int.TryParse(drItem[dataColsCount].ToString(), out ignoreMe))
                                    {
                                        newSeriesValueRow.IdDataType = (int)colDataType.Integer;
                                        newSeriesValueRow.Value = drItem[dataColsCount].ToString();
                                    }
                                    //try to parse for date
                                    else if (DateTime.TryParseExact(drItem[dataColsCount].ToString(),
                                        "ddd MMM dd hh:mm:ss GMT yyyy", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out newDateFormat))
                                    {
                                        newSeriesValueRow.IdDataType = (int)colDataType.Date;
                                        //change date format of each Excel cell
                                        newSeriesValueRow.Value = String.Format("{0:MM/dd/yyyy}",
                                            newDateFormat.AddDays(1));
                                    }
                                    else
                                    {
                                        //if is not integer or date then we will assume is string
                                        newSeriesValueRow.IdDataType = (int)colDataType.String;
                                        newSeriesValueRow.Value = drItem[dataColsCount].ToString();
                                    }
                                    //newSeriesValueRow.IdDataType = 1;
                                    newSeriesValueRow.RowPosition = rowPosition;
                                    smartsocialDB.SeriesValue.InsertOnSubmit(newSeriesValueRow);
                                }
                            }
                            rowConter++;
                            rowPosition++;
                        }
                        smartsocialDB.SubmitChanges();
                        rowConter = 0;
                    }
                }

                //close OleDB connection
                objConn.Close();

                //close SQL DB context var
                smartsocialDB.Connection.Close();
                response.Message = "Success";
                response.Acknowledgment = true;

            }

            catch (Exception ex)
            {
                response.Message = "Error: " + ex.Message;
                response.Acknowledgment = false;
            }
            return response;
        }

        public ReportDataImportResponse FnProcessConversationStream(ReportDataImportRequest request)
        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            // Sets the UI culture to French (France)
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");


            var response = new ReportDataImportResponse();
            try
            {
                var smartsocialDb = new SmartSocialdbDataContext();
                //declare general vars
                var strConn = "";
                const string quote = "\"";
                DateTime newDateFormat;

                //check if is old or new Excel format
                if (Path.GetExtension(request.ReportTemplateObject.openDialgog.FileName.Trim()) == ".xls")
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" + quote + "Excel 8.0;HDR=Yes;IMEX=1" + quote;
                }
                else
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + request.ReportTemplateObject.openDialgog.FileName.Trim() + " ;Extended Properties=" + quote + "Excel 12.0 Xml;HDR=Yes;IMEX=1" + quote;
                }

                //declare OleDB data vars
                OleDbConnection objConn;
                var ds = new DataSet();
                var dt = new OleDbDataAdapter();
                DataTable dtSheet;
                DataRow drSchema;
                var cmdExcel = new OleDbCommand();
                var strFirstSheetName = "";

                //open connection using Excel file via OleDB to check name of first sheet
                objConn = new OleDbConnection(strConn);
                objConn.Open();
                dtSheet = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "Table" });
                var DataRowArray = dtSheet.Select(null, "TABLE_NAME", DataViewRowState.CurrentRows);
                drSchema = dtSheet.Rows[0];
                strFirstSheetName = drSchema["TABLE_NAME"].ToString();

                //because Stream Conversation file have a lot of columns and we don't need all of them then we will
                //use a OleDbDataAdapter to specify the colums we want in order to improve response time
                cmdExcel.Connection = objConn;
                cmdExcel.CommandText = "SELECT SocialNetwork,SenderScreenName,SenderProfileImgUrl,[Sender Followers Count] AS SenderFollowersCount,Message,CreatedTime AS MessageCreatedDate,Permalink,Country FROM [" + strFirstSheetName + "]";
                dt.SelectCommand = cmdExcel;
                dt.Fill(ds);
                var dv = new DataView(ds.Tables[0]);

                //call function that will delete content of temp table
                DeleteSocialPostTmp();

                //connect directly to SQL Server using ADO.NET
                using (var sqlconnection = new SqlConnection(smartsocialDb.Connection.ConnectionString))
                {
                    //open SQL Connection
                    sqlconnection.Open();

                    //copy the datatable to SQL Server Table using SqlBulkCopy
                    using (var sqlBulkCopy = new SqlBulkCopy(smartsocialDb.Connection.ConnectionString))
                    {
                        //set detination table name(the one we created in our SQL Server)
                        sqlBulkCopy.DestinationTableName = "SocialPostTMP";

                        //map columns datatable <--> SQL Server
                        foreach (var column in ds.Tables[0].Columns)
                            sqlBulkCopy.ColumnMappings.Add(column.ToString(), column.ToString());

                        //property to avoi timeout errors when the file is hige
                        sqlBulkCopy.BulkCopyTimeout = 1000000;
                        //property to let know ADO.NET to send the info in several batches instead of one big insert,
                        //this improve response time
                        sqlBulkCopy.BatchSize = int.Parse(ConfigurationSettings.AppSettings["BatchSizeSQLBulk"].ToString());

                        sqlBulkCopy.WriteToServer(ds.Tables[0]);
                    }
                }

                //close OleDB connection
                objConn.Close();

                //call the function that will format the columns MessageCreatedDateFormatted / SenderFollowersCountFormatted of SocialPost table
                UpdateSocialPostFormattedCols(request.ReportTemplateObject.SmartReportId,request.ReportTemplateObject.Keywords.Text);
                response.Message = "Success";
                response.Acknowledgment = true;

            }

            catch (Exception ex)
            {
                response.Message = "Error: " + ex.Message;
                response.Acknowledgment = false;
            }
            return response;
        }

        public ReportDataImportResponse FnProcessTopUser(ReportDataImportRequest request)
        {
            var response = new ReportDataImportResponse();
            try
            {

                //declare SQL DB context var
                var smartsocialDB = new SmartSocialdbDataContext();
                var newSmartChartRow = new SmartChart();
                var listOfTopUsers = new List<TopUserObject>();

                //declare general vars
                var groupCounter = 0;

                
                var rowPos = 0;

                var sReader = new StreamReader(request.ReportTemplateObject.openDialgog.FileName);
                var jReader = new JsonTextReader(sReader);
                var jObject = (JObject)JToken.ReadFrom(jReader);
                foreach (var theItem in jObject["data"])
                {
                    //For each Root Node
                    var returnedNode = new TreeNode("Row >> " + rowPos.ToString());
                    var newTopUserObject = new TopUserObject();

                    groupCounter = groupCounter + 100000;
                    if (theItem["socialProfiles"] != null)
                    {
                        foreach (var theSubItem in theItem["socialProfiles"])
                        {
                            if (theSubItem["username"] != null)
                            {
                                newTopUserObject.Name = theSubItem["username"].ToString();
                            }
                            if (theSubItem["followers"] != null)
                            {
                                newTopUserObject.TotalCount = Convert.ToInt32(theSubItem["followers"].ToString());
                            }
                        }
                    }
                    listOfTopUsers.Add(newTopUserObject);
                }


                var topUserFromList = (from user in listOfTopUsers
                                      orderby user.TotalCount descending
                                      select user).FirstOrDefault<TopUserObject>();

                newSmartChartRow.IdSmartReport = request.ReportTemplateObject.SmartReportId;
                newSmartChartRow.IdChartType = 1;
                newSmartChartRow.ChartName = "Chart for >> " +
                                             Path.GetFileName(
                                                 request.ReportTemplateObject.openDialgog.FileName)
                                                 .Substring(0,
                                                     Path.GetFileName(
                                                         request.ReportTemplateObject.openDialgog.FileName)
                                                         .IndexOf("."));
                newSmartChartRow.FileName =
                    Path.GetFileName(request.ReportTemplateObject.openDialgog.FileName);

                var rowPosition = (smartsocialDB.ChartSeries.Join(smartsocialDB.SeriesValue,
                    ch => ch.IdChartSeries,
                    sv => sv.IdChartSeries,
                    (ch, sv) => new { ChartSeries = ch, SeriesValue = sv })
                    .Where(chSv => chSv.ChartSeries.IdSmartChart == request.ReportTemplateObject.SmartChartId && chSv.ChartSeries.SeriesName.Equals("Term"))
                    .Max(x => x.SeriesValue.RowPosition))+1;

                if (rowPosition == null || rowPosition == 0)
                {
                    rowPosition = 0;
                }



                var newChartTermSeriesRow = new ChartSeries
                {
                    IdSmartChart = request.ReportTemplateObject.SmartChartId,
                    SeriesName = "Term"
                };
                smartsocialDB.ChartSeries.InsertOnSubmit(newChartTermSeriesRow);
                smartsocialDB.SubmitChanges();
                var idTermSeries = newChartTermSeriesRow.IdChartSeries;

                var newChartCountSeriesRow = new ChartSeries
                {
                    IdSmartChart = request.ReportTemplateObject.SmartChartId,
                    SeriesName = "Count"
                };
                
                smartsocialDB.ChartSeries.InsertOnSubmit(newChartCountSeriesRow);
                smartsocialDB.SubmitChanges();

                var idCounterSeries = newChartCountSeriesRow.IdChartSeries;

                var newTermSeriesValueRow = new SeriesValue
                {
                    IdChartSeries = idTermSeries,
                    IdDataType = 1,
                    Value = topUserFromList.Name,
                    RowPosition = rowPosition
                };
                smartsocialDB.SeriesValue.InsertOnSubmit(newTermSeriesValueRow);
                smartsocialDB.SubmitChanges();

                var newCountSeriesValueRow = new SeriesValue
                {
                    IdChartSeries = idCounterSeries,
                    IdDataType = 1,
                    Value = topUserFromList.TotalCount.ToString(),
                    RowPosition = rowPosition
                };
                smartsocialDB.SeriesValue.InsertOnSubmit(newCountSeriesValueRow);
                smartsocialDB.SubmitChanges();
                //close SQL DB context var
                smartsocialDB.Connection.Close();
                response.Message = "Success";
                response.Acknowledgment = true;

            }


            catch (Exception ex)
            {
                response.Message = "Error: " + ex.Message;
                response.Acknowledgment = false;
            }
            return response;
        }

        public int AddReportBaseOnTemplate(int idReport, int idServiceDelivery)
        {
            int? response = 0;
            try
            {
                var smartsocialDb = new SmartSocialdbDataContext();
                smartsocialDb.CreateReportFromTemplate(idReport, idServiceDelivery, ref response);
                smartsocialDb.Dispose();

            }

            catch (Exception e)
            {
                _logger.Error("Error: " + e.Message);
            }

            return (int)response;

        }

        public int AddChartBaseOnTemplate(int smarChartId, int idReport)
        {
            var response = 0;
            try
            {
                var smartsocialDb = new SmartSocialdbDataContext();
                var chartToCopy = smartsocialDb.SmartChart.FirstOrDefault(x => x.IdSmartChart == smarChartId);
                if (chartToCopy != null)
                {
                    var newChart = new SmartChart()
                    {
                        AxisSeriesTitle = chartToCopy.AxisSeriesTitle,
                        AxisValuesTitle = chartToCopy.AxisValuesTitle,
                        ChartName = chartToCopy.ChartName,
                        FileName = chartToCopy.FileName,
                        ChartOrder = chartToCopy.ChartOrder,
                        ChartType = chartToCopy.ChartType,
                        CssClasses = chartToCopy.CssClasses,
                        DataProvider = chartToCopy.DataProvider,
                        IdDataProvider = chartToCopy.IdDataProvider,
                        IdChartType = chartToCopy.IdChartType,
                        IdSmartReport = idReport,
                        HtmlStyles = chartToCopy.HtmlStyles,
                        SocialPostFilter = chartToCopy.SocialPostFilter

                    };
                    smartsocialDb.SmartChart.InsertOnSubmit(newChart);
                    smartsocialDb.SubmitChanges();
                    smartsocialDb.Dispose();
                    response = newChart.IdSmartChart;
                }

            }

            catch (Exception ex)
            {
                _logger.Error("Error adding new chart:" + ex.Message);
            }
            return response;
        }

        void UpdateSocialPostFormattedCols(int idReport,string productName)
        {
            try
            {
                var smartsocialDb = new SmartSocialdbDataContext();
                smartsocialDb.UpdateSocialPostFormattedCols(idReport, productName);
                smartsocialDb.Dispose();
            }
            catch (Exception e)
            {
                _logger.Error("Error: " + e.Message);
            }

        }

        void DeleteSocialPostTmp()
        {
            try
            {

                //connect to the SQL Server
                using (var sqlconnection = new SqlConnection(new SmartSocialdbDataContext().Connection.ConnectionString))
                //set the stored procedure we need to execute
                using (var command = new SqlCommand("truncate table SocialPostTMP", sqlconnection)
                {
                    CommandType = CommandType.Text
                })
                {
                    //open connection, execute stored procedure and finally close the connection
                    sqlconnection.Open();
                    command.ExecuteNonQuery();
                    sqlconnection.Close();
                }
            }
            catch (Exception e)
            {
                _logger.Error("Error: " + e.Message);
            }
        }

    }




}
