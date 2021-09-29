using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebParser;
using WebParser.PullentiWrapper;
using WFClient.Helper;
using WFServerWebAPI.ServiceModel;

namespace WFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ddlParseURL.DataSource = ParsingExamples.URLExamples;
        }

        #region Form events
        async void btnParse_Click(object sender, EventArgs e)
        {
            var url = this.ddlParseURL.Text;

            if (!ValidityChecker.IsURLValid(url))
            {
                MessageBox.Show(this, "Entered address has invalid symbols", "Sorry", MessageBoxButtons.OK);
                return;
            }

            // show actual process
            var progress = new Progress<string>(val => this.lblStatus.Text = val);

            var parsedPageText = new List<string>();

            var result = await Task.Run(() => CrawlAndSaveInDB(url, progress, out parsedPageText));
            if (!result)
            {
                MessageBox.Show(this, "Server side is unavailable, or error due execution", "Sorry", MessageBoxButtons.OK);
                ShowStatusMessage("Parsing failed");
                return;
            }

            ShowStatusMessage("Parsing done");

            // display text
            await Task.Run(() => ShowParsedPageText(parsedPageText));

            var instances = ExtractInstances(parsedPageText);

            // display instances
            await Task.Run(() => ShowInstances(instances));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowStatusMessage("Parsing not started");
        }
        #endregion

        bool CrawlAndSaveInDB(string url, IProgress<string> progress, out List<string> parsedPageText)
        {
            parsedPageText = new List<string>();

            using (var client = new WebAPIServiceClient())
            {
                var isOnline = client.CheckOnline();
                if (!isOnline)
                    return false;

                return client.ParseURL(url, progress, out parsedPageText);
            }            
        }
        List<string> ExtractInstances(List<string> pageText)
        {
            var instances = new List<string>();
            using (IWebParser pullentParser = new PullentiParser())
            {
                instances = pullentParser.GetInstances(string.Join(" ", pageText));
            }

            return instances;
        }
        
        void ShowStatusMessage(string message)
        {
            if (this.lblStatus.InvokeRequired)
            {
                this.lblStatus.BeginInvoke((MethodInvoker)delegate
                {
                    lblStatus.Text = message;
                });
            }
            else
                lblStatus.Text = message;
        }
        void ShowParsedPageText(List<string> pageText)
        {
            if (this.txtPageText.InvokeRequired)
            {
                this.txtPageText.BeginInvoke((MethodInvoker)delegate
                {
                    this.txtPageText.Lines = pageText.ToArray();
                });
            }
            else
                this.txtPageText.Lines = pageText.ToArray();
        }        
        void ShowInstances(List<string> instances)
        {
            foreach (var item in instances)
            {
                if (this.lbInstances.InvokeRequired)
                {
                    this.lbInstances.BeginInvoke((MethodInvoker)delegate
                    {
                        this.lbInstances.Items.Add(item.ToString());
                    });
                }
                else
                    this.lbInstances.Items.Add(item.ToString());
            }
        }
    }
}
