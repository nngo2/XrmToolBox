﻿// PROJECT : MsCrmTools.SampleTool
// This project was developed by Tanguy Touzard
// CODEPLEX: http://xrmtoolbox.codeplex.com
// BLOG: http://mscrmtools.blogspot.com

using System;
using System.Windows.Forms;
using Microsoft.Crm.Sdk.Messages;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace MsCrmTools.SampleTool
{
    public partial class SampleTool : PluginControlBase, IGitHubPlugin, ICodePlexPlugin, IPayPalPlugin, IHelpPlugin, IStatusBarMessenger, ISnapshotable
    {
        #region Base tool implementation

        public SampleTool()
        {
            InitializeComponent();
        }

       
        public void ProcessWhoAmI()
        {
            bool isMultipleCallChecked = cbMultipleCalls.Checked;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving your user id...",
                Work = (w, e) =>
                {
                    // If option multiple calls is selected,
                    // the while loop is just here to illustrate the possibility to cancel
                    // a long running process made of multiple calls
                    do
                    {
                        if (w.CancellationPending)
                        {
                            e.Cancel = true;
                        }
                        var request = new WhoAmIRequest();
                        var response = (WhoAmIResponse)Service.Execute(request);

                        e.Result = response.UserId;
                    } while ((e.Cancel == false) && (isMultipleCallChecked));
                },
                ProgressChanged = e =>
                {
                    // If progress has to be notified to user, use the following method:
                    //SetWorkingMessage("Message to display");

                    // If progress has to be notified to user, through the
                    // status bar, use the following method
                    if (SendMessageToStatusBar != null)
                        SendMessageToStatusBar(this, new StatusBarMessageEventArgs(50, "progress at 50%"));
                },
                PostWorkCallBack = e =>
                {
                    if (!e.Cancelled)
                    {
                        MessageBox.Show(string.Format("You are {0}", (Guid)e.Result));
                    }
                },
                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void BtnWhoAmIClick(object sender, EventArgs e)
        {
            ExecuteMethod(ProcessWhoAmI);

            if(SnapshotSent != null)
            {
                SnapshotSent(this, new SnapshotEventArgs("You requested a WhoAmI call", DateTime.Now));
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelWorker();

            MessageBox.Show("Cancelled");
        }

        #endregion Base tool implementation

        #region Github implementation

        public string RepositoryName
        {
            get { return "GithubRepositoryName"; }
        }

        public string UserName
        {
            get { return "GithubUserName"; }
        }

        #endregion Github implementation

        #region CodePlex implementation

        public string CodePlexUrlName
        {
            get { return "CodePlex"; }
        }

        #endregion CodePlex implementation

        #region PayPal implementation

        public string DonationDescription
        {
            get { return "paypal description"; }
        }

        public string EmailAccount
        {
            get { return "paypal@paypal.com"; }
        }

        #endregion PayPal implementation

        #region Help implementation

        public string HelpUrl
        {
            get { return "http://www.google.com"; }
        }

        #endregion Help implementation

        #region StatusBarMessenger implementation

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

        #endregion

        #region Snapshot implementation

        public event EventHandler<SnapshotEventArgs> SnapshotSent;

        public void RestoreSnapshot(object snapshotData)
        {
            var sd = (Snapshot)snapshotData;
            MessageBox.Show("You requested to restore an item snapshoted at " + ((DateTime)sd.Data).ToString());
        }

        #endregion
    }
}