﻿using msGIS.ProApp_Common_FIWARE_3x;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msGIS.ProPluginDatasource_FiwareHttpClient
{
    public static class Fusion
    {
        // 3.3.05/20231128/msGIS_FIWARE_rt_001: Integration ArcGIS PRO.
        private static readonly string m_ModuleName = "Fusion";

        #region Common

        internal static Global m_Global { get; set; }
        internal static Messages m_Messages { get; set; }
        internal static Fiware_RestApi_NetHttpClient m_Fiware_RestApi_NetHttpClient { get; set; }

        #endregion Common

        internal static Fiware_RestApi_NetHttpClient.UriDatasource m_UriDatasource;
        private static bool m_IsInitialized { get; set; }

        public static async Task<bool> InitAsync(Fiware_RestApi_NetHttpClient.UriDatasource uriDatasource)
        {
            try
            {
                if (!m_IsInitialized)
                {
                    Fusion.m_Global = new Global();
                    Fusion.m_Messages = new Messages(Fusion.m_Global);
                    Fusion.m_Fiware_RestApi_NetHttpClient = new Fiware_RestApi_NetHttpClient(Fusion.m_Global, Fusion.m_Messages);

                    // 3.3.06/20231221/msGIS_FIWARE_rt_008: Datasource URI.
                    m_UriDatasource = uriDatasource;
                    m_IsInitialized = true;
                }
                else
                {
                    //if (!await Fusion.m_Messages.MsAskAsync($"The ProPluginDatasource is initialized already!{Environment.NewLine}Repeat initialisation?", "FIWARE"))
                    //    return false;
                }

                return m_IsInitialized;
            }
            catch (Exception ex)
            {
                await Fusion.m_Messages.PushAsyncEx(ex, m_ModuleName, "InitAsync");
                return false;
            }
        }

    }
}