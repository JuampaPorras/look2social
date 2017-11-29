using System.Drawing;
using System.Windows.Forms;

namespace SmartSocial.Desktop.Templates
{
    public class ReportTemplate
    {
        public Button CustomButton { get; set; }
        public Label TitleLabel { get; set; }
        public Label ErrorLabel { get; set; }
        public OpenFileDialog openDialgog { get; set; }
        public string Extension { get; set; }
        public int ReportTypeId { get; set; }
        public int SmartReportId { get; set; }
        public int SmartChartId { get; set; }
        public string ChartName { get; set; }
        public string FileLoadFunctionName { get; set; }
        public bool Validated { get; set; }
        public TextBox Keywords { get; set; }
        public Label KeywordsLabel { get; set; }

        public ReportTemplate() {
            CustomButton = new Button();
            TitleLabel = new Label();
            ErrorLabel = new Label { ForeColor = Color.Red };
            openDialgog = new OpenFileDialog();
            Keywords = new TextBox();
            KeywordsLabel = new Label();
            Extension = "";
            FileLoadFunctionName = "";
            ChartName = "";
            ReportTypeId = 0;
            SmartReportId = 0;
            Validated = false;
            SmartChartId = 0;
        }

    }
}
