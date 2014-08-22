﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeDevPnP.PowerShell.Commands.Base;
using OfficeDevPnP.PowerShell.Commands.Base.PipeBinds;
using System.Management.Automation;
using OfficeDevPnP.PowerShell.Core;

namespace OfficeDevPnP.PowerShell.Commands
{
    public class SPOWebCmdlet : SPOCmdlet
    {
        [Parameter(Mandatory = false)]
        public SPOWebPipeBind Web = new SPOWebPipeBind();

        internal Microsoft.SharePoint.Client.Web SelectedWeb
        {
            get
            {
                return GetWeb();
            }
        }

        private Microsoft.SharePoint.Client.Web GetWeb()
        {
            Microsoft.SharePoint.Client.Web web = ClientContext.Web;

            if (Web.Id != Guid.Empty)
            {
                web = SPOWeb.GetWebById(Web.Id, ClientContext);
            }
            else if (!string.IsNullOrEmpty(Web.Url))
            {
                web = SPOWeb.GetWebByUrl(Web.Url, ClientContext);
            }
            else if (Web.Web != null)
            {
                web = Web.Web;
            }
            return web;
        }
    }
}
