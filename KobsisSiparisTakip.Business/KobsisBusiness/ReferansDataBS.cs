﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFrame.Business;
using WebFrame.DataAccess;
using WebFrame.DataType.Common.Attributes;

namespace KobsisSiparisTakip.Business
{
    [ServiceConnectionNameAttribute("KobsisConnectionString")]
    public class ReferansDataBS : BusinessBase
    {
        public DataTable ReferansVerileriniGetir(int musteriID, string siparisSeri)
        {
            DataTable dt = new DataTable();
            IData data = GetDataObject();
            string sqlText = @"SELECT
	                            R.MusteriID
	                            ,R.RefID
	                            ,RD.RefDetayID
	                            ,RDK.SiparisSeriID
	                            ,R.RefAdi
	                            ,RD.RefDetayAdi
                            FROM dbo.REF AS R
	                            INNER JOIN dbo.REF_DETAY AS RD ON R.RefID=RD.RefID
	                            INNER JOIN dbo.REF_DETAY_SIPARIS_SERI AS RDK ON RDK.RefDetayID=RD.RefDetayID
                            WHERE R.MusteriID=@MusteriID
                            ORDER BY R.MusteriID,R.RefID,RD.RefDetayID,RDK.SiparisSeriID";
            data.AddSqlParameter("SiparisSeriID", siparisSeri, SqlDbType.VarChar, 50);
            data.AddSqlParameter("MusteriID", musteriID, SqlDbType.Int, 50);
            data.GetRecords(dt, sqlText);
            return dt;
        }
    }
}