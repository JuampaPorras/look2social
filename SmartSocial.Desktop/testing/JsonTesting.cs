using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartSocial.Desktop.testing
{
    public partial class JsonTesting : Form
    {
        public JsonTesting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            //Test code for Reading JSON files

            //See more docs at http://www.newtonsoft.com/json/help/html/QueryJsonLinq.htm

            StreamReader sReader = new StreamReader("../../testing/57_.txt");
            JsonTextReader jReader = new JsonTextReader(sReader);
            JObject jObject = (JObject)JToken.ReadFrom(jReader);
            foreach (var theItem in jObject["groups"])
            {   //For each Root Node
                TreeNode ReturnedNode = new TreeNode(theItem["label"].ToString() + " - " + theItem["weight"].ToString());
                
                if (theItem["groups"] != null) //Nodes that don't have children return NULL for Groups
                {   //For each SubItem
                    foreach (var theSubItem in theItem["groups"])
                    {
                        ReturnedNode.Nodes.Add(theSubItem["label"].ToString() + " - " + theSubItem["weight"].ToString());
                    }   
                }
                
                treeView1.Nodes.Add(ReturnedNode);
            }
        }

        private void JsonTesting_Load(object sender, EventArgs e)
        {

        }
    }
}
