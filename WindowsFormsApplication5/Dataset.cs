
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace WindowsFormsApplication5
{
	class DataSet
	{
		#region global
		public static String DBserverName = "den1.mssql8.gear.host";
		public static String DBuserId = "asudb";
		public static String DBpassword = "asyourise-12";
		public static String DBPort = "1433";

		public static String DBName = "asudb";

		public static SqlConnection myconn = new SqlConnection();
		public static SqlCommand cmd;

		public static SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();

		public static void setConnection()
		{
			try
			{
				if (myconn.State == ConnectionState.Closed)
				{
					myBuilder = new SqlConnectionStringBuilder();

					myBuilder.InitialCatalog = getDBName();
					myBuilder.DataSource = getDBServerName();
					myBuilder.UserID = getDBUserID();
					myBuilder.Password = getDBPassword();

					myconn = new SqlConnection(myBuilder.ConnectionString);

					myconn.Open();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Database Connection Error");
			}
		}

		public static bool checkConnection()
		{
			try
			{
				if (myconn.State == ConnectionState.Closed)
				{
					myBuilder = new SqlConnectionStringBuilder();

					myBuilder.InitialCatalog = getDBName();
					myBuilder.DataSource = getDBServerName();
					myBuilder.UserID = getDBUserID();
					myBuilder.Password = getDBPassword();


					myconn = new SqlConnection(myBuilder.ConnectionString);
					cmd = new SqlCommand();

					cmd.CommandType = CommandType.Text;
					cmd.Connection = myconn;

					myconn.Open();
				}

			}
			catch (Exception ex)
			{
				return false;
			}
			finally
			{
				myconn.Close();
			}

			return true;
		}


		public static SqlCommand getCommand()
		{
			setConnection();
			cmd = new SqlCommand();

			cmd.CommandType = CommandType.Text;
			cmd.Connection = myconn;
			return cmd;
		}


		public static String getDBServerName()
		{
			return DBserverName;
		}


		public static String getDBUserID()
		{
			return DBuserId;
		}


		public static String getDBPassword()
		{
			return DBpassword;
		}

		public static String getDBPort()
		{
			return DBPort;
		}

		public static SqlConnection getConnection()
		{
			return myconn;
		}

		public static String getDBName()
		{
			return DBName;
		}

		public static void closeConnection()
		{
			myconn.Close();
		}

		public static DataTable getDataTable(String sql)
		{
			SqlCommand cmd = DataSet.getCommand();

			cmd.CommandText = sql;

			DataTable dt = new DataTable();

			dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));

			return dt;
		}



		public static void executeQuery(String sql)
		{
		    SqlCommand cmd = DataSet.getCommand();

			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			closeConnection();
		}

		#endregion

		#region Ehna
		public static long getUserID(String username, String Password)    //loginform
		{
			String sql = @"select login.id as id  from asudb.dbo.login
                           where login.username = '" + username + "' AND login.password = '" + Password + "';";

			DataTable dt = getDataTable(sql);

			if (dt.Rows.Count > 0)
			{
				DataRow dataRow = dt.Rows[0];

				long userID = Convert.ToInt32(dataRow[dt.Columns.IndexOf("id")]);






				return userID;
			}
			else
			{
				return 0; // wrong user or password
			}
		}
        //public static long getMaxrID()    //MAXID
        //{
        // String sql = @"select MAX(id) as maximumID from asudb.dbo.personal_info";

        //    DataTable dt = getDataTable(sql);

        //    if (dt.Rows.Count > 0)
        //    {
        //        DataRow dataRow = dt.Rows[0];

        //        long MaxID = Convert.ToInt64(dataRow[dt.Columns.IndexOf("maximumID")]);


        //        return MaxID;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}


		public static long InsertUserInfo(string f, string m, string l, string t, string g, int age, string address, string city, string governorate, string occu, string mari, string menst, DateTime fv)
		{

			String sql = @"INSERT INTO  asudb.dbo.personal_info (fname, mname, lname, tele,gender,age,adress,city,governorate,occupation,maritialstatus,mensturalhistory,firstvisit) OUTPUT INSERTED.id as id
            VALUES ('"+ f + "',' " + m + "','" + l + "','"+ t +"','" + g + "','" + age + "', '"+ address + "','" +city+ "','" +governorate+ "','" +occu+ "','" +mari+ "','" +menst+ "', '" +fv+  "'  )";
			DataTable dt = getDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dataRow = dt.Rows[0];

                long id = Convert.ToInt64(dataRow[dt.Columns.IndexOf("id")]);

                return id;
            }
            else
            {
                return -1;
            }

		}

        public static DataTable getPatientHistory(long p_id)
        {
            String sql = @"SELECT * FROM asudb.dbo.History WHERE p_id ='"+p_id +"'" ;
            DataTable dt = getDataTable(sql);

            return dt;
        }

			public static void InsertHistoryInfo(DateTime cd, string sd, string ap, string cc, string f, int t, int D, int nm, string m, string b, int pd, int wl,int wlg, string  hd,string main	, long p_id)
		{

			String sql = @"UPDATE asudb.dbo.History SET currentdate='"+ cd + "',statusofdiagnosis='" + sd + "',Abdominalpain='" + ap + "',currentcomplain='"+ cc +"',fever='" + f + "',Tesnismus='" + t + "',Diarrhea= '"+ D + "',noofmotions='" +nm+ "',muscs='" +m+ "',bleeding='" +b+ "',perianaldischarge='" +pd+ "',weightloss='" +wl+ "',weightlossinkg= '" +wlg+  "',historydetails= '" +hd+  "',mainfestations= '" +main+ "' WHERE p_id='" +p_id+ "' ";
            executeQuery(sql);


		}

            public static void InsertHistoryFirstTime(DateTime cd, long p_id)
            {

                String sql = @"INSERT INTO  asudb.dbo.History (currentdate,p_id) VALUES ('" + cd + "','" + p_id + "' )";
                executeQuery(sql);


            }


		public static void UpdateExamInfo(string sys, string di, string pu, string te, string rr, string w, string h, string bm, string ge, string le	,long p_id)
		{

			String sql = @"UPDATE  asudb.dbo.Exam_details SET Systolic='"+ sys + "',diastolic='" + di + "',pulse='"+ pu + "',Temp='"+ te +"',Resp_rate= '"+ rr +"',Weight='"+ w +"',Hight='"+ h +"',BMI='"+bm+"',General_findings='"+ge+"',Local_findings='"+le+"' WHERE p_id ='"+p_id+ "'";
			executeQuery(sql);


		}

        public static DataTable getPatientExamInfo(long p_id)
        {
            String sql = @"SELECT * FROM asudb.dbo.Exam_details WHERE p_id ='" + p_id + "'";
            DataTable dt = getDataTable(sql);

            return dt;
        }

        public static void InsertExamFirst(long p_id)
        {
            String sql = @"INSERT INTO  asudb.dbo.Exam_details (p_id) VALUES ('" + p_id +  "')";
            executeQuery(sql);
        }
		//search form
		public static DataTable getAllpatientinfo(string name)
		{
			String sql = @"SELECT id,fname,mname,lname,age,tele FROM asudb.dbo.personal_info where   personal_info.fname Like  '" +name + "'";

			DataTable dt = getDataTable(sql);

			return dt;
		}
        public static DataTable selectAllPatients()
        {
            String sql = @"SELECT id,fname,mname,lname,age,tele FROM asudb.dbo.personal_info";

            DataTable dt = getDataTable(sql);

            return dt;
        }
		//SURGERYDATAENTERY
		public static void InsertSurgeryInfo(DateTime ds,string si,string opd,string sc,int p_id )
        {
            String sql = @"INSERT INTO  asudb.dbo.surgery (Dateofsurgery,surgicalindication,operativedetails,surgicalcomplication,p_id) VALUES ('"+ ds + "','"+ si + "',' " + opd + "','" + sc + "','"+ p_id+ "')";
		    executeQuery(sql);
        }

        public static void InsertlabenteryInfo(DateTime labdat, string hb, string hema, string mcv, string rdw, string latlets, string tlc, string neuro, string lym, string ceos, string seriron, string tibc, string serumfe, string ESR, string CRP, string ANCA, string ASCA, string fecacal, string TTG, string ARBCs, string puscells, string clodef, int para, string toolscs, String paranotes, String othernotes, string tt, int tp, String Qua, int HB, int HBV, int HC, int HIV, string Am, string LI, string NA, string K, string Ca, string Mg, string ph, string FALT, string FAST, string FTP, string FAlb, string fdb, string ftb, string FALP, string FFGT, string INR, string SCreat, string BUn, string otherdetails, int p_id, string LARFib)
        {

            String sql = @"INSERT INTO  asudb.dbo.labentery (labdate,cbchb,cbchema,cbcmcv,cbcrdw,cbcplatlets,cbctlc,cbcneuro,cbclym,cbceos,ironstudyseriron,ironstudytibc,ironstudyserumfe,iaimESR,iaimCRP,iaimpANCA,iaimASCA,iaimfecacal,iaimAntiTTG,SARBCs,SApuscells,SAclodef,SApara,SAstoolcs,SAparanotes,SAothernotes,INFtt,INFtp,INQua,INHB,INHBV,INHC,INHIV,BCAm, BCLI,BCNA,BCK,BCCa,BCMg,BCph,LARFALT,LARFAST,LARFTp,LARFAlb,LARFdb,LARFtb,LARFALP,LARFGGT,LARFINR,LARFScreat,LARFBUN,otherlabdetails,p_id,LARFib)
                            VALUES ('" + labdat + "',' " + hb + "','" + hema + "','" + mcv + "','" + rdw + "','" + latlets + "', '" + tlc + "','" + neuro + "','" + lym + "','" + ceos + "','" + seriron + "','" + tibc + "', '" + serumfe + "', '" + ESR + "', '" + CRP + "', '" + ANCA + "', '" + ASCA + "', '"+fecacal+"','" + TTG + "' ,'" + ARBCs + "', '" + puscells + "' ,'" + clodef + "' ,'" + para + "' ,'" + toolscs + "','" + paranotes + "','" + othernotes + "','" + tt + "','" + tp + "','" + Qua + "','" + HB + "','" + HBV + "','" + HC + "','" + HIV + "','" + Am + "' ,'" + LI + "' ,'" + NA + "' ,'" + K + "' ,'" + Ca + "' ,'" + Mg + "' ,'" + ph + "' ,'" + FALT + "','" + FAST + "' ,'" + FTP + "' ,'" + FAlb + "' ,'" + fdb + "' ,'" + ftb + "','" + FALP + "' ,'" + FFGT + "' ,'" + INR + "' ,'" + SCreat + "' ,'" + BUn + "' ,'" + otherdetails + "','" + p_id + "','" + LARFib + "' )";

            executeQuery(sql);


        }
		public static void Updatelabentery(DateTime labdat, int hb, int hema, int mcv, int rdw, int latlets, int tlc, int neuro, int lym, int ceos, int seriron, int tibc, int serumfe, int ESR, int CRP, int ANCA, int ASCA,int fecacal, int TTG, int ARBCs, int puscells, int clodef, int para, int toolscs, String paranotes, String othernotes, int tt, int tp, String Qua, int HB, int HBV, int HC, int HIV, int Am, int LI, int NA, int K, int Ca, int Mg, int ph, int FALT, int FAST, int FTP, int FAlb, int fdb, int ftb, int FALP, int FFGT, int INR, int SCreat, int BUn, string otherdetails, int p_id, int LARFib)
        {

string sql=	@"UPDATE asudb.dbo.labentery
   SET
      [cbchema]			= '"+hema+@"'
      ,[cbchb]				= '"+hb+@"'
      ,[cbcmcv]				= '"+mcv+@"'
      ,[cbcrdw]				= '"+rdw+@"'
      ,[cbcplatlets]		= '"+latlets+@"'
      ,[cbctlc]				= '"+tlc+@"'
      ,[cbcneuro]			= '"+neuro+@"'
      ,[cbclym]				= '"+lym+@"'
      ,[cbceos]				= '"+ceos+@"'
      ,[ironstudyseriron]	= '"+seriron+@"'
      ,[ironstudytibc]		= '"+tibc+@"'
      ,[ironstudyserumfe]	= '"+serumfe+@"'
      ,[iaimESR]			= '"+ESR+@"'
      ,[iaimCRP]			= '"+CRP+@"'
      ,[iaimpANCA]			= '"+ANCA+@"'
      ,[iaimASCA]			= '"+ASCA+@"'
      ,[iaimfecacal]		= '"+fecacal+@"'
      ,[iaimAntiTTG]		= '"+TTG+@"'
      ,[SARBCs]				= '"+ARBCs+@"'
      ,[SApuscells]			= '"+puscells+@"'
      ,[SAclodef]			= '"+clodef+@"'
      ,[SApara]				= '"+para+@"'
      ,[SAstoolcs]			= '"+toolscs+@"'
      ,[SAparanotes]		= '"+paranotes+@"'
      ,[SAothernotes]		= '"+othernotes+@"'
      ,[INFtt]				= '"+tt+@"'
      ,[INFtp]				= '"+tp+@"'
      ,[INQua]				= '"+Qua+@"'
      ,[INHB]				= '"+HB+@"'
      ,[INHBV]				= '"+HBV+@"'
      ,[INHC]				= '"+HC+@"'
      ,[INHIV]				= '"+HIV+@"'
      ,[BCAm]				= '"+Am+@"'
      ,[BCLI]				= '"+LI+@"'
      ,[BCNA]				= '"+NA+@"'
      ,[BCK]				= '"+K+@"'
      ,[BCCa]				= '"+Ca+@"'
      ,[BCMg]				= '"+Mg+@"'
      ,[BCph]				= '"+ph+@"'
      ,[LARFALT]			= '"+FALT+@"'
      ,[LARFAST]			= '"+FAST+@"'
      ,[LARFTp]				= '"+FTP+@"'
      ,[LARFAlb]			= '"+FAlb+@"'
      ,[LARFdb]				= '"+fdb+@"'
      ,[LARFtb]				= '"+ftb+@"'
      ,[LARFALP]			= '"+FALP+@"'
      ,[LARFGGT]			= '"+FFGT+@"'
      ,[LARFINR]			= '"+INR+@"'
      ,[LARFScreat]			= '"+SCreat+@"'
      ,[LARFBUN]			= '"+BUn+@"'
      ,[otherlabdetails]	= '"+otherdetails+@"'
      ,[LARFib]				= '"+LARFib+@"'
         WHERE p_id ='"+p_id+ "'AND  labdate='"+labdat+"'";


		executeQuery(sql);
			//27/2
}
        public static long InsertenterographyyInfo(DateTime date, string enst, int musleh, string jeE, string ilE, string RcE, string TcE, string LcE, string ScE, string ReE, int Msl, int subdema, string jedema, string ildema, string Rcdema, string Tcdema, string Lcdema, string Scdema, string Redema, int muralab, string jela, string illa, string Rcla, string Tcla, string Lcla, string Scla, string Rela, string jemt, string ilmt, string Rcmt, string Tcmt, string Lcmt, string Scmt, string Remt, int fd, int cs, int mf, string jens, string ilns, string Rcns, string Tcns, string Lcns, string Scns, string Rens, int presd, string jep, string ilp, string Rcp, string Tcp, string lcp, string Scp, string Rep, int Lh, string ttl, int cf, int caf, string clot, string cdab, string cdot, string cdvt, string ctof, string cabs, string cttf, string comother, string oth, string enter, int p_id)
        {

            String sql = @"INSERT INTO asudb.dbo.enterography
           (date,Entrostudy,mucosalenh,jejEa,ilEa,RcEa,TcEa,LcEa,ScEa,ReEa,Mucosalirrefi,submucosaledema,jethofSMedema,ilthofSMedema ,RcthofSMedema,TcthofSMedema ,LcthofSMedema ,ScthofSMedema,RethofSMedema,muralabscess,jelengthactivity,illengthactivity  ,Rclengthactivity   ,Tclengthactivity  ,Lclengthactivity    ,Sclengthactivity,Relengthactivity,jemuralthickness,ilmuralthickness,Rcmuralthickness,Tcmuralthickness    ,Lcmuralthickness  ,Scmuralthickness   ,Remuralthickness   ,Fatedema   ,combsign,Muralfib,jeNarstr,ilNarstr ,RcNarstr,TcNarstr,LcNarstr ,ScNarstr  ,ReNarstr  ,Prestenoticdial,jePrestenoticdiam,ilPrestenoticdiam  ,RcPrestenoticdiam ,TcPrestenoticdiam  ,LcPrestenoticdiam,ScPrestenoticdiam  ,RePrestenoticdiam ,LossofHaus,totallength  ,compfistula  ,compAbscessformation  ,complenoftrack,compdiamofab,compdiamoftrack,compvolofab,comptypeoffistula,compabsloc,compothertypefis,compotherabsloc,otherentrofindings ,EntroReport ,p_id)  OUTPUT INSERTED.id as id

		       VALUES ('" + date + "',' " + enst + "','" + musleh + "','" + jeE + "','" + ilE + "','" + RcE + "', '" + TcE + "','" + LcE + "','" + ScE + "','" + ReE + "','" + Msl + "','" + subdema + "', '" + jedema + "', '" + ildema + "', '" + Rcdema + "', '" + Tcdema + "', '" + Lcdema + "', '"+Scdema+"','" + Redema+ "' ,'" + muralab + "', '" + jela + "' ,'" + illa + "' ,'" + Rcla + "' ,'" + Tcla + "','" + Lcla+ "','" + Scla + "','" + Rela + "','" + jemt + "','" + ilmt + "','" + Rcmt + "','" + Tcmt + "','" + Lcmt + "','" + Scmt + "','" + Remt + "' ,'" + fd + "' ,'" + cs + "' ,'" + mf + "' ,'" + jens + "' ,'" + ilns + "' ,'" + Rcns + "' ,'" + Tcns + "','" + Lcns + "' ,'" + Scns + "' ,'" + Rens + "' ,'" + presd + "' ,'" + jep + "','" + ilp + "' ,'" + Rcp + "' ,'" + Tcp + "' ,'" + lcp + "' ,'" + Scp + "' ,'" + Rep + "','"+Lh+"', '" + ttl + "', '" + cf + "', '" + caf + "', '" + clot + "', '" + cdab + "', '" + cdot + "', '" + cdvt + "', '" + ctof + "', '" + cabs + "', '" + cttf + "', '" + comother + "', '" + oth + "', '" + enter+ "','" + p_id + "' )";


            DataTable dt = getDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dataRow = dt.Rows[0];

                long id = Convert.ToInt32(dt.Rows[0]["id"]);

                return id;
            }
            else
            {
                return -1;
            }


        }

		//3/6/2019
		public static int Insertultrasonicinfo(int uscheck, DateTime date, string moje, string moil, string moRc, string moTc, string moLc, string moSi, int subed, string smtje, string smtil, string smtRc, string smtTc, string smtLc, string smtSi, string slje, string slil, string slRc, string slTc, string slLc, string slSi,string mtje,string mtil,string mtrc,string mttc,string mtlc,string mtsi, string mhje, string mhil, string mhrc, string mhtc, string mhlc, string mhsi, string mpje, string mpil, string mprc, string mptc, string mplc, string mpsi, string mrje, string mril, string mrrc, string mrtc, string mrlc, string mrsi, string mpije, string mpiil, string mpirc, string mpitc, string mpilc, string mpisi, int fat, int local, string llsj, string llsi, string llsrc, string llstc, string llslc, string llssi, string llvj, string llvi, string llvrc, string llvtc,string llvlc,string llvsi,int muralfib,int luminalstric,int pres,string jdiam,string idiam,string rtcdiam,string trcdiam,string ltcdiam,string sigcdiam,string tl,int pof,string leng,string fis_dia,string type,string othertypefis,int pa,string dia,string vol,string loa,string otherlloac, string oth, string ultra, int p_id)
		{

			String sql = @"INSERT INTO asudb.dbo.ultrasonicradio
           (ultrasoniccheck,Dateofus,moje,moil,morc,motc,molc,mosi,subedema,smtje,smtil ,smtrc,smttc ,smtlc ,smtsi,slje,slil  ,slrc   ,sltc  ,sllc ,slsi,mtje,mtil,mtrc,mttc,mtlc,mtsi,mhje,mhil ,mhrc,mhtc,mhlc ,mhsi ,mpje,mpil  ,mprc ,mptc  ,mplc,mpsi,mrje,mril  ,mrrc ,mrtc  ,mrlc,mrsi,mpije,mpiil,mpirc,mpitc,mpilc,mpisi,fatcreepsign,locallnenla,llsje,llsil,llsrc,llstc,llslc,llssi,llvje,llvil,llvrc,llvtc,llvlc,llvsi,muralfib,luminalstric,presdialation,jejuPresDiam,ileumPresDiam,rtColonPresDiam,trColonPresDiam,ltColonPresDiam,sigColonPresDiam,tcl,pof,length,fis_diameter,typeoffis,othertypefis,pa,Diam,volume,loa,otherlloac,otherfinding,ultrasoundreport ,p_id)  OUTPUT INSERTED.id as id

		       VALUES ('" + uscheck + "','" + date + "','" + moje + "','" + moil + "','" + moRc + "', '" + moTc + "','" + moLc + "','" + moSi + "','" + subed + "' , '" + smtje + "' ,'" + smtil + "' ,'" + smtRc + "' ,'" + smtTc + "','" + smtLc + "','" + smtSi + "','" + slje + "','" + slil + "','" + slRc + "','" + slTc + "','" + slLc + "','" + slSi +"','" + mtje + "','" + mtil + "','" + mtrc + "','" + mttc + "','" + mtlc + "','" + mtsi + "' ,'" + mhje + "' ,'" + mhil + "' ,'" + mhrc + "' ,'" + mhtc + "','" + mhlc + "' ,'" + mhsi + "'   ,'" + mpje + "','" + mpil + "' ,'" + mprc + "' ,'" + mptc + "' ,'" + mplc + "' ,'" + mpsi + "' ,'" + mrje + "', '" + mril + "', '" + mrrc + "', '" + mrtc + "', '" + mrlc + "', '" + mrsi + "', '" + mpije + "', '" + mpiil + "', '" + mpirc + "', '" + mpitc + "', '" + mpilc + "', '" + mpisi + "', '" + fat + "', '" + local + "', '" + llsj + "', '" + llsi + "', '" + llsrc + "','" + llstc + "','" + llslc + "','" + llssi + "','" + llvj + "','" + llvi + "','" + llvrc + "','" + llvtc + "','" + llvlc + "','" + llvsi + "', '" + muralfib + "','" + luminalstric + "','" + pres + "','" + jdiam + "','" + idiam + "','" + rtcdiam + "','" + trcdiam + "','" + ltcdiam + "','" + sigcdiam + "','" + tl + "','" + pof + "','" + leng + "','" + fis_dia + "','" + type + "','" + othertypefis + "','" + pa + "' ,'" + dia + "','" + vol + "','" + loa + "','" + otherlloac + "','" + oth + "','" + ultra + "','" + p_id + "' )";


			DataTable dt = getDataTable(sql);
			if (dt.Rows.Count > 0)
			{
				DataRow dataRow = dt.Rows[0];

                int id = Convert.ToInt32(dt.Rows[0]["id"]);

				return id;
			}
			else
			{
				return -1;
			}


		}

        public static DataTable getUltrasonicImages(int p_id)
        {
            string sql = @"SELECT u_image FROM asudb.dbo.u_images WHERE u_id='" + p_id + "'";
            DataTable dt = getDataTable(sql);

            return dt;
        }
        public static void insertUltraImages(int id, byte[] image)
        {
            String sql = @"INSERT INTO  asudb.dbo.u_images (u_id,u_image) VALUES ('" + id + "','" + image + "'  )";
            executeQuery(sql);
        }

		//3/6/2019
		public static DataTable getultrasonicDates(int p_id)
		{
            string sql = @"SELECT Dateofus FROM asudb.dbo.ultrasonicradio WHERE p_id='" + p_id + "'";
			DataTable dt = getDataTable(sql);

			return dt;
		}
		//3/6/2019
		public static DataTable getUltrasonic(string date, int p_id)
		{

			string sql = @"SELECT * FROM asudb.dbo.ultrasonicradio WHERE Dateofus='" + date + "' AND p_id='" + p_id + "' ";
			DataTable dt = getDataTable(sql);
			return dt;
		}
		public static DataTable getUltrasonics(string date, int p_id)
		{

			string sql = @"SELECT * FROM asudb.dbo.ultrasonicradio WHERE Dateofus='" + date + "' AND p_id='" + p_id + "' ";
			DataTable dt = getDataTable(sql);
			return dt;
		}
		//3/8/2018
		public static DataTable getDrugDates(int p_id)
		{
			string sql = @"SELECT Recorddate FROM asudb.dbo.druglist WHERE p_id='" + p_id + "'";
			DataTable dt = getDataTable(sql);

			return dt;
		}
		//3/8/2019
		public static DataTable getDrugs(string date, int p_id)
		{

			string sql = @"SELECT * FROM asudb.dbo.druglist WHERE Recorddate='" + date + "' AND p_id='" + p_id + "' ";
			DataTable dt = getDataTable(sql);
			return dt;
		}
		//3/8/2019
        public static int Insertdruginfo(DateTime Rd, int sterodate, string dose, string weekno, string sternotes, int Asas, string Asad, string Asaw, int Asao, string Asaod, string Asaow, int Asar, string Asard, string Asarw, int immmtx, string immmd, string immmw, int imma, string immad, string immaw, int bif, string bifd, string bifw, int bad, string badd, string badw, int bgo, string bgod, string bgow, int bus, string busd, string busw, string Biolgnotes, int supvit, int supca, int supppi, int suppfa, int suppiron, string suproute, string supdose, int antiat, string antidetails, string othermedication, int p_id)
		{
			string sql = @"INSERT INTO asudb.dbo.druglist(Recorddate,steroidtreat,Dose,Wekkno,Steroidsnotes,Asas,Asad,Asaw,Asao,Asaod,Asaow,Asar,Asard,Asarw,immmtx,immmd,immmw,imma,immad,immaw,bif,bifd,bifw,bad,badd,badw,bgo,bgod,bgow,bus,busd,busw,Biolgnotes,supvit,supca,supppi,suppfa,suppiron,suproute,supdose,antiat,antidetails,othermedication,p_id)  OUTPUT INSERTED.id as id VAlUES('" + Rd + "','" + sterodate + "','" + dose + "','" + weekno + "','" + sternotes + "','" + Asas + "','" + Asad + "','" + Asaw + "','" + Asao + "','" + Asaod + "','" + Asaow + "','" + Asar + "','" + Asard + "','" + Asarw + "','" + immmtx + "','" + immmd + "','" + immmw + "','" + imma + "','" + immad + "','" + immaw + "','" + bif + "','" + bifd + "','" + bifw + "','" + bad + "','" + badd + "','" + badw + "','" + bgo + "','" + bgod + "','" + bgow + "','" + bus + "','" + busd + "','" + busw + "','" + Biolgnotes + "','" + supvit + "','" + supca + "','" + supppi + "','" + suppfa + "','" + suppiron + "','" + suproute + "','" + supdose + "','" + antiat + "','" + antidetails + "','" + othermedication + "','" + p_id + "')";




			DataTable dt = getDataTable(sql);
			if (dt.Rows.Count > 0)
			{
				DataRow dataRow = dt.Rows[0];

				int id = Convert.ToInt32(dt.Rows[0]["id"]);

				return id;
			}
			else
			{
				return -1;
			}


		}
















		public static DataTable getPatientLabDates( int p_id)
        {
            string sql= @"SELECT labdate FROM asudb.dbo.labentery WHERE p_id='"+p_id+ "'";
            DataTable dt = getDataTable(sql);

            return dt;
        }
		//27/2
		   public static DataTable getPatiententerographyDates( int p_id)
        {
            string sql= @"SELECT date FROM asudb.dbo.enterography WHERE p_id='"+p_id+ "'";
            DataTable dt = getDataTable(sql);

            return dt;
        } //27/2
         public static DataTable getEnterography(string date,int p_id)
        {

            string sql = @"SELECT * FROM asudb.dbo.enterography WHERE date='"+date+"' AND p_id='"+p_id+"' ";
            DataTable dt = getDataTable(sql);
            return dt;
        }

        public static DataTable getLabDetails(string date,int p_id)
        {

            string sql = @"SELECT * FROM asudb.dbo.labentery WHERE labdate='"+date+"' AND p_id='"+p_id+"' ";
            DataTable dt = getDataTable(sql);
            return dt;
        }

        public static void InsertLab(DateTime ld, int p_id)
        {
            String sql = @"INSERT INTO  asudb.dbo.labentery (labdate,p_id) VALUES ('"  + ld + "','"+ p_id+ "'  )";
            executeQuery(sql);
        }
		     // 3/2/2019

		    public static DataTable getpathologydata(string date,int p_id)
        {

            string sql = @"SELECT * FROM asudb.dbo.pathology WHERE patholgydate='"+date+"' AND p_id='"+p_id+"' ";
            DataTable dt = getDataTable(sql);
            return dt;
        }
		//3/2/2019
		public static void Insertpatholgy(DateTime ld, int p_id)
        {
            String sql = @"INSERT INTO  asudb.dbo.patholgy (patholgydate,p_id) VALUES ('"  + ld + "','"+ p_id+ "'  )";
            executeQuery(sql);
        }
		//3/2/2019
		 public static DataTable getPatholgyDates(int p_id)
        {

            string sql = @"SELECT patholgydate FROM asudb.dbo.pathology WHERE  p_id='"+p_id+"' ";
            DataTable dt = getDataTable(sql);
            return dt;
        }
				public static void insertImages(int id, byte[] image)
				{
						String sql = @"INSERT INTO  asudb.dbo.imageentro (enntroid,imageentro) VALUES ('" + id + "','" + image + "'  )";
						executeQuery(sql);
				}


				public static DataTable selectImages(int e_id)
				{

						string sql = @"SELECT * FROM asudb.dbo.imageentro WHERE enntroid='" + e_id + "' ";
						DataTable dt = getDataTable(sql);
						return dt;
				}

				public static void parametrizedInsert(int e_id, byte[] image)
				{

						string sql = "INSERT INTO  asudb.dbo.imageentro (enntroid,imageentro) VALUES  (@id,@img);";

						using (SqlConnection connection = new SqlConnection(DataSet.myBuilder.ConnectionString))
						using (SqlCommand command = new SqlCommand(sql, connection))
						{
								connection.Open();
								var entroid = new SqlParameter("id", SqlDbType.Int);
							 // entroid.Value = e_id;

								var img = new SqlParameter("img", SqlDbType.VarBinary);
							 // img.Value = image;

								command.Parameters.AddWithValue("@id", e_id);
								command.Parameters.AddWithValue("@img", image);
								command.ExecuteNonQuery();
								connection.Close();
						}

				}

                public static void parametrizedInsertUltra(int e_id, byte[] image)
                {

                    string sql = "INSERT INTO  asudb.dbo.u_images (u_id,u_image) VALUES  (@id,@img);";

                    using (SqlConnection connection = new SqlConnection(DataSet.myBuilder.ConnectionString))
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        var entroid = new SqlParameter("id", SqlDbType.Int);
                        // entroid.Value = e_id;

                        var img = new SqlParameter("img", SqlDbType.VarBinary);
                        // img.Value = image;

                        command.Parameters.AddWithValue("@id", e_id);
                        command.Parameters.AddWithValue("@img", image);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                }

		//3/2/20199
                public static void Insertpatholgydata(DateTime date, string il, string ilad, string ilc, string nii, string Er, int uc, int gra, string other, string irco, string cradc, string balco, string cry, string lamin, int lamen, int ulceo, int gran, string otherfind, string finalreport, int pid)
		{

			String sql = @"INSERT INTO  asudb.dbo.pathology (patholgydate, ileir, ilad, ilic,Niil,ilER,ucil,grail,otherileal,irco,cradco,balco,crycco,lamineosco,lamneutroco,ulceco,granilco,otherfindings,finalreport,p_id)
            VALUES ('"+ date + "',' " + il+ "','" + ilad + "','"+ ilc +"','" + nii + "','" + Er + "', '"+ uc + "','" +gra+ "','" +other+ "','" +irco+ "','" +cradc+ "','" +balco+ "', '" +cry+  "'   , '" +lamin+  "'  , '" +lamen+  "'  , '" +ulceo+  "', '" +gran+  "'  , '" +otherfind+  "'  , '" +finalreport+  "','"+pid+"') ";
            executeQuery(sql);
			}

                public static DataTable getSurgery(string date,int p_id)
                {

                    string sql = @"SELECT * FROM asudb.dbo.surgery WHERE Dateofsurgery='" + date + "' AND p_id= '"+p_id+"' ";
                    DataTable dt = getDataTable(sql);
                    return dt;
                }

                public static DataTable getSurgeryDates(int p_id)
                {

                    string sql = @"SELECT * FROM asudb.dbo.surgery WHERE  p_id= '" + p_id + "' ";
                    DataTable dt = getDataTable(sql);
                    return dt;
                }

		public static DataTable getEndoDates(int p_id)
		{

			string sql = @"SELECT * FROM asudb.dbo.Endoscopy WHERE  p_id= '" + p_id + "' ";
			DataTable dt = getDataTable(sql);
			return dt;
		}
		public static DataTable getEndoall(string date, int p_id)
		{

			string sql = @"SELECT * FROM asudb.dbo.Endoscopy WHERE Endodate='" + date + "' AND p_id= '" + p_id + "' ";
			DataTable dt = getDataTable(sql);
			return dt;
		}

		public static void Insertendoscopydata(DateTime date, int Segment, string eryr, string erys, string eryl, string erytr, string eryrt, string eryti, string eryn, string vr, string vs, string vl, string vtr, string vrt, string vti, string vn, string ur, string us, string ul, string utr, string urt, string uti, string un, string usr, string uss, string usl, string ustr, string usrt, string usti, string usn, string uar, string uas, string ual,string uatr,string uart,string uati,string uan,int Muscoalero,int Muscoalfria,string Nr,string Ns,string Nl,string Ntr,string Nrt,string Nti,string Nn, int Pancolitis, int pid)
		{

			String sql = @"INSERT INTO  asudb.dbo.Endoscopy (Endodate, Segment, eryr, erys,eryl,erytr,eryrt,eryti,eryn,vr,vs,vl,vtr,vrt,vti,vn,ur,us,ul,utr,urt,uti,un,usr,uss,usl,ustr,usrt,usti,usn,uar,uas,ual,uatr,uart,uati,uan,Muscoalero,Muscoalfria,Nr,Ns,Nl,Ntr,Nrt,Nti,Nn,Pancolitis,p_id)
            VALUES ('" + date + "',' " + Segment + "','" + eryr + "','" + erys + "','" + eryl+ "','" + erytr + "', '" + eryrt + "','" + eryti + "','" + eryn + "','" + vr + "','" + vs + "','" + vl + "', '" + vtr + "'   , '" + vrt + "'  , '" + vti + "'  , '" + vn + "', '" + ur + "'  , '" + us+ "'  , '" + ul + "','" + utr + "','" + urt + "','" + uti + "','" + un + "','" + usr + "','" + uss + "','" + usl + "','" + ustr + "','" + usrt + "','" + usti + "','" + usn + "','" + uar + "','" + uas + "','" + ual + "','" + uatr + "','" + uart + "','" + uati + "','" + uan + "','" + Muscoalero + "','" + Muscoalfria + "','" + Nr + "','" + Ns + "','" + Nl + "','" + Ntr + "','" + Nrt + "','" + Nti + "','" + Nn + "','" + Pancolitis + "','" + pid + "') ";
			executeQuery(sql);
		}
		public static DataTable getActionDates(int p_id)
		{

            string sql = @"SELECT planDate FROM asudb.dbo.Actionplan WHERE  p_id= '" + p_id + "' ";
			DataTable dt = getDataTable(sql);
			return dt;
		}
		public static DataTable getActionall(string date, int p_id)
		{

			string sql = @"SELECT * FROM asudb.dbo.Actionplan WHERE planDate='" + date + "' AND p_id= '" + p_id + "' ";
			DataTable dt = getDataTable(sql);
			return dt;
		}

        public static void InsertActionplandata(string Clinicalactivityindex, string CDAI, string TWID, string Endoscopicactivity, string SESendoscopic, string Monteralactivityindexno, string Monteralindexle, string Mayoscore, string currentpatientstatus, string Detailsofcplan, string Decisionstuff, DateTime Datenextvisit, string Responsibleresident, DateTime planDate, int pid)
		{

			String sql = @"INSERT INTO  asudb.dbo.Actionplan (Clinicalactivityindex, CDAI, TWID, Endoscopicactivity,SESendoscopic,Monteralactivityindexno,Monteralindexle,Mayoscore,currentpatientstatus,Detailsofcplan,Decisionstuff,Datenextvisit,Responsibleresident,planDate,p_id)
            VALUES ('" + Clinicalactivityindex + "',' " + CDAI + "','" + TWID + "','" + Endoscopicactivity + "','" + SESendoscopic + "','" + Monteralactivityindexno + "', '" + Monteralindexle + "','" + Mayoscore + "','" + currentpatientstatus + "','" + Detailsofcplan + "','" + Decisionstuff + "','" + Datenextvisit + "', '" + Responsibleresident + "'   , '" + planDate + "'  , '" + pid + "'  ) ";
			executeQuery(sql);
		}

		  
		//3/10/2019 update action plane yryes
        public static void updateActionplandata(string Clinicalactivityindex, string CDAI, string TWID, string Endoscopicactivity, string SESendoscopic, string Monteralactivityindexno, string Monteralindexle, string Mayoscore, string currentpatientstatus, string Detailsofcplan, string Decisionstuff, DateTime Datenextvisit, string Responsibleresident, DateTime planDate, int pid, int id)
		{

			string sql = @"UPDATE asudb.dbo.Actionplan SET Clinicalactivityindex='" + Clinicalactivityindex + "'" +
				", CDAI='" + CDAI + "', TWID='" + TWID + "', Endoscopicactivity='" + Endoscopicactivity + "', " +
				"SESendoscopic ='" + SESendoscopic + "', Monteralactivityindexno='" + Monteralactivityindexno + "', " +
				"Monteralindexle='" + Monteralindexle + "', Mayoscore='" + Mayoscore + "', " +
				"currentpatientstatus='" + currentpatientstatus + "', Detailsofcplan='" + Detailsofcplan + "', Decisionstuff='" + Decisionstuff + "', Datenextvisit='" + Datenextvisit + "', Responsibleresident='" + Responsibleresident + "', planDate='" + planDate + "'  WHERE p_id='" + pid + "' And id='" + id + "' ;";

			     executeQuery(sql);
		}
		//3/11/2019
		public static void Updateendoscopydata(DateTime date, int Segment, string eryr, string erys, string eryl, string erytr, string eryrt, string eryti, string eryn, string vr, string vs, string vl, string vtr, string vrt, string vti, string vn, string ur, string us, string ul, string utr, string urt, string uti, string un, string usr, string uss, string usl, string ustr, string usrt, string usti, string usn, string uar, string uas, string ual, string uatr, string uart, string uati, string uan, int Muscoalero, int Muscoalfria, string Nr, string Ns, string Nl, string Ntr, string Nrt, string Nti, string Nn, int Pancolitis, int pid,int id)
		{



			string sql = @"UPDATE asudb.dbo.Endoscopy SET Endodate='" + date + "'" +
				", Segment='" + Segment + "', eryr='" + eryr + "', erys='" + erys + "', " +
				"eryl ='" + eryl + "', erytr='" + erytr + "', " + "eryrt='" + eryrt + "', eryti='" + eryti + "', eryn='" + eryn + "', vr='" + vr + "', vs='" + vs + "', vl='" + vl + "', vtr='" + vtr + "', vrt='" + vrt + "', vti='" + vti + "', vn='" + vn + "', ur='" + ur + "', us='" + us + "', ul='" + ul + "', utr='" + utr + "', urt='" + urt + "', uti='" + uti + "', un='" + un + "', usr='" + usr + "', uss='" + uss + "', usl='" + usl + "', ustr='" + ustr + "', usrt='" + usrt + "', usti='" + usti + "', usn='" + usn + "', uar='" + uar + "', uas='" + uas + "',ual='" + ual + "', uatr='" + uatr + "', uart='" + uart + "', uati='" + uati + "', uan='" + uan + "', Muscoalero='" + Muscoalero + "', Muscoalfria='" + Muscoalfria + "', Nr='" + Nr + "', Ns='" + Ns + "', Nl='" + Nl + "', Ntr='" + Ntr + "', Nrt='" + Nrt + "', Nti='" + Nti + "', Nn='" + Nn + "', Pancolitis='" + Pancolitis + "',   WHERE p_id='" + pid + "' And id='" + id + "';";

			executeQuery(sql);
		}
		//11/3/2019
		public static void Updatepatholgydata(DateTime date, string il, string ilad, string ilc, string nii, string Er, int uc, int gra, string other, string irco, string cradc, string balco, string cry, string lamin, int lamen, int ulceo, int gran, string otherfind, string finalreport, int pid,int id)
		{
			string sql = @"UPDATE asudb.dbo.pathology SET patholgydate='" + date + "'" +
			", ileir='" + il + "', ilad='" + ilad + "', ilic='" + ilc + "', " +
			" Niil ='" + nii + "', ilER='" + Er + "', " + "ucil='" + uc + "', grail='" + gra + "', " + "otherileal='" + other + "', irco='" + irco + "', cradco='" + cradc + "', balco='" + balco + "', crycco='" + cry + "', lamineosco='" + lamin + "', lamneutroco='" + lamen + "', ulceco='" + ulceo + "', granilco='" + gran + "', otherfindings='" + otherfind + "', finalreport='" + finalreport + "',    WHERE p_id='" + pid + "' And id='" + id + "';";

			executeQuery(sql);
		}
		//3/11/2019
		public static void UpdateSurgeryInfo(DateTime ds, string si, string opd, string sc, int pid,int id)
		{



			string sql = @"UPDATE asudb.dbo.surgery SET Dateofsurgery='" + ds + "'" +
			", surgicalindication='" + si + "', operativedetails='" + opd + "', surgicalcomplication='" + sc + "',     WHERE p_id='" + pid + "' And id='" + id + "';";

			executeQuery(sql);
		}

		public static void Updatedruginfo(DateTime Rd, int sterodate, string dose, string weekno, string sternotes, int Asas, string Asad, string Asaw, int Asao, string Asaod, string Asaow, int Asar, string Asard, string Asarw, int immmtx, string immmd, string immmw, int imma, string immad, string immaw, int bif, string bifd, string bifw, int bad, string badd, string badw, int bgo, string bgod, string bgow, int bus, string busd, string busw, string Biolgnotes, int supvit, int supca, int supppi, int suppfa, int suppiron, string suproute, string supdose, int antiat, string antidetails, string othermedication, int p_id, int id)
		{
			string sql = @"UPDATE asudb.dbo.druglist SET Recorddate='" + Rd + "'" +
		", steroidtreat='" + sterodate + "', Dose ='" + dose + "', Wekkno='" + weekno + "'" +
		",Steroidsnotes='" + sternotes + "', Asas='" + Asas + "', " + "Asad='" + Asad + "', Asaw='" + Asaw + "', " + "Asao='" + Asao + "', Asaod='" + Asaod + "', Asaow='" + Asaow + "', Asar='" + Asar + "', Asard='" + Asard + "', Asarw='" + Asarw + "', immmtx='" + immmtx + "', immmd='" + immmd + "', immmw='" + immmw + "', imma='" + imma + "', immad='" + immad + "',immaw='" + immaw + "',    bif='" + bif + "',    bifd='" + bifd + "',    bifw='" + bifw + "',    bad='" + bad + "',    badd='" + badd + "',    badw='" + badw + "',    bgo='" + bgo + "',    bgod='" + bgod + "',    bgow='" + bgow + "',    bus='" + bus + "',    busd='" + busd + "',    busw='" + busw + "',    Biolgnotes='" + Biolgnotes + "',    supvit='" + supvit + "',  supca='" + supca + "',  supppi='" + supppi + "',  suppfa='" + suppfa + "',  suppiron='" + suppiron + "',  suproute='" + suproute + "',  antiat='" + antiat + "', antidetails='" + antidetails + "',  othermedication='" + othermedication + "',         WHERE p_id='" + p_id + "' And id='" + id + "';";

			executeQuery(sql);

		}
		public static void  Updateultrasonicinfo(int uscheck, DateTime date, string moje, string moil, string moRc, string moTc, string moLc, string moSi, int subed, string smtje, string smtil, string smtRc, string smtTc, string smtLc, string smtSi, string slje, string slil, string slRc, string slTc, string slLc, string slSi, string mtje, string mtil, string mtrc, string mttc, string mtlc, string mtsi, string mhje, string mhil, string mhrc, string mhtc, string mhlc, string mhsi, string mpje, string mpil, string mprc, string mptc, string mplc, string mpsi, string mrje, string mril, string mrrc, string mrtc, string mrlc, string mrsi, string mpije, string mpiil, string mpirc, string mpitc, string mpilc, string mpisi, int fat, int local, string llsj, string llsi, string llsrc, string llstc, string llslc, string llssi, string llvj, string llvi, string llvrc, string llvtc, string llvlc, string llvsi, int muralfib, int luminalstric, int pres, string jdiam, string idiam, string rtcdiam, string trcdiam, string ltcdiam, string sigcdiam, string tl, int pof, string leng, string fis_dia, string type, string othertypefis, int pa, string dia, string vol, string loa, string otherlloac, string oth, string ultra, int p_id,int id)
		{
			string sql = @"UPDATE asudb.dbo.ultrasonicradio SET ultrasoniccheck='" + uscheck + "'" +
				  ", Dateofus='" +date + "', moje ='" + moje + "', moil='" + moil + "'" +
			   ",morc='" + moRc + "', motc='" + moTc + "', " + "molc='" + moLc + "',mosi ='" + moSi + "', " + "subedema='" + subed + "', smtje='" + smtje + "', smtil='" + smtil + "', smtrc='" + smtRc + "', smttc='" + smtTc + "',smtlc ='" + smtLc + "', smtsi='" + smtSi + "', slje='" + slje + "', slil='" + slil + "', slrc='" + slRc + "', sltc='" + slTc + "',sllc='" + slLc + "',    slsi='" + slSi + "',    mtje='" + mtje + "',    mtil='" + mtil + "',    mtrc='" + mtrc + "',   mttc='" + mttc + "',    mtlc='" + mtlc + "',    mtsi='" + mtsi + "',    mhje='" + mhje + "',  mhil='" + mhil + "',  mhrc='" + mhrc + "',    mhtc='" + mhtc + "',    mhlc='" + mhlc + "',    mhsi='" + mhsi + "',    mpje='" + mpje + "',    mpil='" + mpil + "',  mprc='" + mprc + "',  mptc='" + mptc + "',  mplc='" + mplc + "',  mpsi='" + mpsi + "',  mrje='" + mrje + "',  mril='" + mril + "', mrrc='" + mrrc + "',  mrtc='" + mrtc + "', mrlc='" + mrlc + "', mrsi='" + mrsi + "', mpije='" + mpije + "', mpiil='" + mpiil + "', mpirc='" + mpirc + "', mpitc='" + mpitc + "', mpilc='" + mpilc + "', mpisi='" + mpisi + "', fatcreepsign='" + fat + "', locallnenla='" + local + "', llsje='" + llsj + "', llsil='" + llsi + "', llsrc='" + llsrc + "', llstc='" + llstc + "', llslc='" + llslc + "', llssi='" + llssi + "', llvje='" + llvj + "', llvil='" + llvi+ "', llvrc='" + llvrc + "', llvtc='" + llvtc + "', llvlc='" + llvlc + "', llvsi='" + llvsi + "', muralfib='" + muralfib + "', luminalstric='" + luminalstric + "', presdialation='" + pres + "', jejuPresDiam='" + jdiam + "', ileumPresDiam='" + idiam + "', rtColonPresDiam='" + rtcdiam + "', trColonPresDiam='" + trcdiam + "', ltColonPresDiam='" + ltcdiam + "', sigColonPresDiam='" + sigcdiam + "', tcl='" + tl + "', pof='" + pof + "', length='" + leng + "', fis_diameter='" + fis_dia + "', typeoffis='" + type + "', othertypefis='" + othertypefis + "', pa='" + pa + "', Diam='" + dia + "', volume='" + vol + "', loa='" + loa + "', otherlloac='" + otherlloac + "',  otherfinding='" + oth + "', ultrasoundreport='" + ultra + "',        WHERE p_id='" + p_id + "' And id='" + id + "';";
    
			executeQuery(sql);
		}
		public static void UpdateUserInfo(string f, string m, string l, string t, string g, int age, string address, string city, string governorate, string occu, string mari, string menst, DateTime fv,int id)
		{



			string sql = @"UPDATE asudb.dbo.personal_info SET fname'" + f + "'" +
				  ", mname='" + m + "', lname ='" + l + "', tele='" + t + "'" +
			   ",gender='" + g + "', age='" + age + "', " + "adress='" + address + "',city ='" + city + "', " + "governorate='" + governorate + "', occupation='" + occu + "', maritialstatus='" + mari + "', mensturalhistory='" + menst + "', where id='" + id + "';";
			executeQuery(sql);
		}



		/*
		public static DataTable getAllBuildings()
		{
			String sql = @"select id , name from flowers_park.buildings;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getAllVisibleBuildings()
		{
			String sql = @"SELECT id,name FROM flowers_park.buildings where is_visible = 1;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getFloorsNo(int buildingID)
		{
			String sql = @"select distinct floor_no from flowers_park.appartments where
							appartments.building_id = '" + buildingID + "';";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getAppsNo(int buildingID, int floorNo)
		{
			String sql = @"select distinct app_no from flowers_park.appartments where
							appartments.building_id = '" + buildingID + "' AND appartments.floor_no = '" + floorNo + "';";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getAppsByFloor(int buildingID, int floorNo)
		{
			String sql = "select appartments.id as appID, appartments.app_type_id , "
				+ "CONCAT(buildings.name,\"-\",floor_no, \"-\", app_no) AS appNo, clients.client_name , " +
				@"app_maintenance , administrative_expenses , app_area , garden_area ,  roof_building_area ,
				 roof_empty_area , app_building_meter_price , app_empty_meter_price , number_of_garages , garage_price ,
				((app_building_meter_price * (app_area + roof_building_area)) + (app_empty_meter_price * (garden_area + roof_empty_area)) + administrative_expenses + app_maintenance + (number_of_garages * garage_price)) AS totalPrice,
				 ( (app_building_meter_price * (app_area + roof_building_area)) + (app_empty_meter_price * (garden_area + roof_empty_area)) ) AS app_price,
				( (app_building_meter_price * (app_area + roof_building_area)) + (app_empty_meter_price * (garden_area + roof_empty_area)) + administrative_expenses + app_maintenance ) AS priceWithoutGarage
				 from(flowers_park.appartments
				left outer  join flowers_park.reserves on appartments.id = reserves.app_id)
				left outer JOIN flowers_park.clients ON reserves.client_id = clients.id , flowers_park.buildings ,
				flowers_park.appartments_types
				 where appartments.building_id = " + buildingID + " AND floor_no = " + floorNo + @"
				AND appartments.building_id = flowers_park.buildings.id AND appartments.app_type_id = appartments_types.id
				order by appID
				; ";

			DataTable dt = getDataTable(sql);

			return dt;

		}

		public static DataTable getAppsByAppNo(int buildingID, int floorNo, int appNo)
		{
			String sql = "select appartments.id as appID, appartments.app_type_id , "
				+ "CONCAT(buildings.name,\"-\",floor_no, \"-\", app_no) AS appNo, clients.client_name , " +
				@"app_maintenance , administrative_expenses , app_area , garden_area ,  roof_building_area ,
				 roof_empty_area , app_building_meter_price , app_empty_meter_price , number_of_garages , garage_price ,
				((app_building_meter_price * (app_area + roof_building_area)) + (app_empty_meter_price * (garden_area + roof_empty_area)) + administrative_expenses + app_maintenance + (number_of_garages * garage_price)) AS totalPrice,
				 ( (app_building_meter_price * (app_area + roof_building_area)) + (app_empty_meter_price * (garden_area + roof_empty_area)) ) AS app_price,
				( (app_building_meter_price * (app_area + roof_building_area)) + (app_empty_meter_price * (garden_area + roof_empty_area)) + administrative_expenses + app_maintenance ) AS priceWithoutGarage
				 from(flowers_park.appartments
				left outer  join flowers_park.reserves on appartments.id = reserves.app_id)
				left outer JOIN flowers_park.clients ON reserves.client_id = clients.id , flowers_park.buildings ,
				flowers_park.appartments_types
				 where appartments.building_id = " + buildingID + " AND appartments.floor_no = " + floorNo +
				 " AND appartments.app_no = " + appNo + @" AND appartments.building_id = flowers_park.buildings.id AND
				  appartments.app_type_id = appartments_types.id
					order by appID
					; ";

			DataTable dt = getDataTable(sql);

			return dt;

		}


		public static DataTable getAppsByBuilding(int buildingID)
		{
			String sql = "select appartments.id as appID, appartments.app_type_id , "
				+ "CONCAT(buildings.name,\"-\",floor_no, \"-\", app_no) AS appNo, clients.client_name , " +
				@"app_maintenance , administrative_expenses , app_area , garden_area ,  roof_building_area ,
				 roof_empty_area , app_building_meter_price , app_empty_meter_price , number_of_garages , garage_price ,
				((app_building_meter_price * (app_area + roof_building_area)) + (app_empty_meter_price * (garden_area + roof_empty_area)) + administrative_expenses + app_maintenance + (number_of_garages * garage_price)) AS totalPrice,
				 ( (app_building_meter_price * (app_area + roof_building_area)) + (app_empty_meter_price * (garden_area + roof_empty_area)) ) AS app_price,
				( (app_building_meter_price * (app_area + roof_building_area)) + (app_empty_meter_price * (garden_area + roof_empty_area)) + administrative_expenses + app_maintenance ) AS priceWithoutGarage
				 from(flowers_park.appartments
				left outer  join flowers_park.reserves on appartments.id = reserves.app_id)
				left outer JOIN flowers_park.clients ON reserves.client_id = clients.id , flowers_park.buildings ,
				flowers_park.appartments_types
				 where appartments.building_id = " + buildingID + @"
				AND appartments.building_id = flowers_park.buildings.id AND appartments.app_type_id = appartments_types.id
				order by appID
				";

			DataTable dt = getDataTable(sql);

			return dt;

		}


		public static bool checkAdminPassword(String password)
		{
			try
			{
				String sql = @"select id from flowers_park.users where users.user_type = '" + Varibles.AdminID + "' AND blocked = 0 AND password = '" + password + "';";

				DataTable dt = getDataTable(sql);

				if (dt.Rows.Count > 0)
				{
					return true;
				}
				else
				{
					return false;
				}

			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public static void updateAppartment(int appID, double app_maintanace, double expenses, double app_area, double gardenArea
			, double roof_building_area, double roof_empty_area, double app_building_meter_price, double app_empty_meter_price
			, int noOfGarages, double garagePrice)
		{
			String sql = @"UPDATE `flowers_park`.`appartments` SET `app_maintenance`='" + app_maintanace + "'" +
				", `administrative_expenses`='" + expenses + "', `app_area`='" + app_area + "', `garden_area`='" + gardenArea + "', " +
				"`roof_building_area`='" + roof_building_area + "', `roof_empty_area`='" + roof_empty_area + "', " +
				"`app_building_meter_price`='" + app_building_meter_price + "', `app_empty_meter_price`='" + app_empty_meter_price + "', " +
				"`number_of_garages`='" + noOfGarages + "', `garage_price`='" + garagePrice + "' WHERE `id`='" + appID + "';";

			executeQuery(sql);

		}

		public static DataTable getUsers()
		{
			String sql = @"SELECT users.id , users.user_type , username , password , users_types.type , blocked FROM flowers_park.users , flowers_park.users_types
							WHERE user_type = users_types.id AND users.id <> 1 ;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static void updateUser(int id, String username, String password, int userType, bool isBlocked)
		{
			int blocked = 0;
			if (isBlocked)
			{
				blocked = 1;
			}
			else
			{
				blocked = 0;
			}
			String sql = @"UPDATE `flowers_park`.`users` SET `username`='" + username + "', `password`='" + password + "'," +
						"`user_type`='" + userType + "', `blocked`=" + blocked + " WHERE `id`='" + id + "';";

			executeQuery(sql);
		}

		public static void addUser(String username, String password, int userType, bool isBlocked)
		{
			int blocked = 0;
			if (isBlocked)
			{
				blocked = 1;
			}
			else
			{
				blocked = 0;
			}
			String sql = @"INSERT INTO `flowers_park`.`users`
					(`username`, `password`, `user_type`, `blocked`)
					VALUES ('" + username + "', '" + password + "', '" + userType + "', " + isBlocked + ");";

			executeQuery(sql);
		}

		public static DataTable getLog(String userID)
		{
			String sql = @"SELECT username , action , description , date FROM flowers_park.log , flowers_park.users
							where users.id = log.user_id AND user_id LIKE '" + userID + "'" +
							"order by date desc;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getClientsByName(String clientName)
		{
			String sql = @"SELECT id, client_name, client_mob, client_address, client_file,  client_session
							FROM flowers_park.clients
							WHERE (client_name LIKE '" + clientName + "')";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getClientsNamesByName(String clientName)
		{
			String sql = @"SELECT id, client_name
							FROM flowers_park.clients
							WHERE (client_name LIKE '" + clientName + "')";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getDataTableOfClients()
		{
			String sql = @"SELECT id, client_name, client_mob, client_address, client_file,  client_session
							FROM flowers_park.clients
							WHERE (id = '0')";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static void insertNewClient(String clientName, String clientMob, String clientAddress, String clientFile, int clientSession)
		{
			String sql = @"INSERT INTO `flowers_park`.`clients` (`client_name`, `client_mob`, `client_address`, `client_file`, `client_session`)
						VALUES ('" + clientName + "', '" + clientMob + "', '" + clientAddress + "', '" + clientFile + "', '" + clientSession + "');";

			executeQuery(sql);
		}

		public static void updateClient(String clientName, String clientMob, String clientAddress, String clientFile, int clientSession, int clientID)
		{
			String sql = @"UPDATE `flowers_park`.`clients`
						SET `client_name`='" + clientName + "', `client_mob`='" + clientMob + "', `client_address`='" + clientAddress + "',"
						+ "`client_file`='" + clientFile + "', `client_session`='" + clientSession + "' WHERE `id`='" + clientID + "';";

			executeQuery(sql);
		}

		public static void deleteClient(int clientID)
		{
			String sql = "DELETE FROM `flowers_park`.`clients` WHERE `id`='" + clientID + "';";

			executeQuery(sql);
		}

		public static void insertReserve(int reserve_id, int client_id, double area)
		{
			String sql = @"INSERT INTO `flowers_park`.`reserves` (`id`,`client_id`, `area`)
						VALUES ('" + reserve_id + "' ,'" + client_id + "' , '" + area + "');";

			executeQuery(sql);
		}

		public static DataTable getReservesByClient(int clientID)
		{
			String sql = "SELECT reserves.id , reserves.area , reserve_ammount , CONCAT(buildings.name,\"-\",floor_no, \"-\", app_no) AS appNo FROM flowers_park.reserves " +
						   @" left outer join
							flowers_park.appartments on reserves.app_id = appartments.id
							left outer join flowers_park.buildings on appartments.building_id = buildings.id
							where reserves.client_id = " + clientID + ";";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static void deleteReserve(int reserveID)
		{
			String sql = @"DELETE FROM `flowers_park`.`reserves` WHERE `id`='" + reserveID + "';";

			executeQuery(sql);
		}

		public static DataTable getAllInvoicesMonthes()
		{
			String sql = "SELECT id , inv_month FROM flowers_park.invoices_types;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getAllReservesByClientID(int clientID)
		{
			String sql = @"SELECT  id
							from flowers_park.reserves
							where client_id = " + clientID + @"
							order by id;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getReserveByID(int reserveID)
		{
			String sql = @"SELECT  reserves.area , reserves.app_id , buildings.name,
						floor_no , app_no FROM flowers_park.reserves left outer join
						flowers_park.appartments on reserves.app_id = appartments.id
						left outer join flowers_park.buildings on appartments.building_id = buildings.id
						where reserves.id = " + reserveID + " ;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getAvailibleFloors(int buildingID, double appArea)
		{
			String sql = @"SELECT distinct appartments.floor_no FROM flowers_park.appartments left outer join flowers_park.reserves
							on appartments.id = reserves.app_id
							where reserves.id is null AND appartments.building_id = " + buildingID + @"
							AND appartments.app_area = " + appArea + " ;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getAvailibleApps(int buildingID, double appArea, int floorNo)
		{
			String sql = @"SELECT flowers_park.appartments.id , appartments.app_no FROM flowers_park.appartments left outer join flowers_park.reserves
							on appartments.id = reserves.app_id
							where reserves.id is null AND appartments.building_id = " + buildingID + @"
							AND appartments.app_area = " + appArea + @"
							AND flowers_park.appartments.floor_no = " + floorNo + " ;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static void assignReserve(int reserveID, int app_id, double reserveAmmount)
		{
			String sql = @"update flowers_park.reserves
						set app_id = " + app_id + " , reserve_ammount = " + reserveAmmount + @"
						where id = " + reserveID + " ;";

			executeQuery(sql);
		}

		public static DataTable getAppInfo(int appID)
		{
			String sql = @"SELECT app_maintenance , administrative_expenses , app_area ,
							garden_area , roof_building_area , roof_empty_area , app_building_meter_price ,
							app_empty_meter_price , number_of_garages , garage_price
							FROM flowers_park.appartments
							where id = " + appID + ";";

			DataTable dt = getDataTable(sql);

			return dt;
		}



		public static void deleteAllReserveInvoices(int reserve_id)
		{
			String sql = @"DELETE FROM flowers_park.reserves_invoices
							where reserve_id = " + reserve_id + ";";

			executeQuery(sql);
		}

		public static void deleteAllInvoices(int reserve_id)
		{
			String sql = @"delete FROM flowers_park.invoices
							where reserve_id = " + reserve_id + "; ";

			executeQuery(sql);
		}

		public static int getMaximumInvID(int client_id)
		{
			String sql = @"select MAX(invoices.id ) as maximumID from flowers_park.invoices , flowers_park.reserves
							where reserves.id = invoices.reserve_id AND reserves.client_id = " + client_id + ";";

			DataTable dt = getDataTable(sql);
			int maximumID = -1;
			if (dt.Rows.Count > 0)
			{
				DataRow dataRow = dt.Rows[0];

				try
				{
					maximumID = Convert.ToInt32(dataRow[dt.Columns.IndexOf("maximumID")]);
				}
				catch (Exception ex)
				{

				}
			}

			return maximumID;
		}

		public static void insertInvoice(int inv_id, int inv_month_id, int reserve_id, double inv_ammount, int inv_index)
		{
			String sql = @"INSERT INTO `flowers_park`.`invoices` (`id`, `inv_type_id`, `reserve_id`, `ammount`, `inv_index`)
						VALUES ('" + inv_id + "', '" + inv_month_id + "', '" + reserve_id + "', '" + inv_ammount + "', '" + inv_index + "');";

			executeQuery(sql);
		}

		public static DataTable getAllInvoicesByClientID(int clientID)
		{
			String sql = @"SELECT invoices.id , " +
						"CONCAT(buildings.name,\"-\",floor_no, \"-\", app_no) AS appNo , " +
						@"invoices.ammount , invoices_types.start_date , invoices.payment_date , invoices.is_paid ,
						invoices.inv_penalty ,
						invoices.inv_penalty_date , invoices.inv_penalty_is_paid , invoices_types.due_date
						FROM flowers_park.invoices , flowers_park.reserves ,
						flowers_park.invoices_types , flowers_park.appartments , flowers_park.buildings
						where invoices.reserve_id = reserves.id AND invoices.inv_type_id = invoices_types.id
						AND reserves.app_id = appartments.id AND appartments.building_id = buildings.id
						AND reserves.client_id = " + clientID + " ; ";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getAllInvoicesByMonthID(int monthID)
		{
			String sql = @"SELECT invoices.id , " +
						"CONCAT(buildings.name,\"-\",floor_no, \"-\", app_no) AS appNo , " +
						@"invoices.ammount , invoices_types.start_date , invoices.payment_date , invoices.is_paid ,
						invoices.inv_penalty ,
						invoices.inv_penalty_date , invoices.inv_penalty_is_paid , invoices_types.due_date
						, clients.client_name
						FROM flowers_park.invoices , flowers_park.reserves ,
						flowers_park.invoices_types , flowers_park.appartments , flowers_park.buildings
						, flowers_park.clients
						where invoices.reserve_id = reserves.id AND invoices.inv_type_id = invoices_types.id
						AND reserves.app_id = appartments.id AND appartments.building_id = buildings.id
						AND reserves.id = invoices.reserve_id AND reserves.client_id  = clients.id
						AND invoices.inv_type_id = " + monthID + " ; ";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getAllInvoices()
		{
			String sql = @"SELECT invoices.id , " +
						"CONCAT(buildings.name,\"-\",floor_no, \"-\", app_no) AS appNo , " +
						@"invoices.ammount , invoices_types.start_date , invoices.payment_date , invoices.is_paid ,
						invoices.inv_penalty ,
						invoices.inv_penalty_date , invoices.inv_penalty_is_paid , invoices_types.due_date
						, clients.client_name
						FROM flowers_park.invoices , flowers_park.reserves ,
						flowers_park.invoices_types , flowers_park.appartments , flowers_park.buildings
						, flowers_park.clients
						where invoices.reserve_id = reserves.id AND invoices.inv_type_id = invoices_types.id
						AND reserves.app_id = appartments.id AND appartments.building_id = buildings.id
						AND reserves.id = invoices.reserve_id AND reserves.client_id  = clients.id ; ";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getAppsByClientID(int clientID)
		{
			String sql = "SELECT CONCAT(buildings.name,\"-\",floor_no, \"-\", app_no) AS appNo" +
						" , reserves.app_id " +
						@"FROM flowers_park.reserves , flowers_park.appartments , flowers_park.buildings
						where  reserves.app_id = appartments.id AND appartments.building_id = buildings.id
						AND reserves.client_id = " + clientID + "; ";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static void collectInv(int invoiceID, String paymentDate)
		{
			String sql = @"UPDATE `flowers_park`.`invoices` SET `is_paid`=1 , `payment_date`= '" + paymentDate + "' WHERE `id`= " + invoiceID + ";";

			executeQuery(sql);
		}

		public static void setPenaltyInv(int invoiceID, double paymentAmmount)
		{
			String sql = @"UPDATE `flowers_park`.`invoices` SET `inv_penalty`=" + paymentAmmount + " , `inv_penalty_is_paid`=0 WHERE `id`=" + invoiceID + ";";

			executeQuery(sql);
		}

		public static void collectPenalty(int invoiceID, String paymentDate)
		{
			String sql = @"UPDATE `flowers_park`.`invoices` SET `inv_penalty_is_paid`=1, `inv_penalty_date`='" + paymentDate + "' WHERE `id`= " + invoiceID + ";";

			executeQuery(sql);
		}

		public static void setNoPenaltyInv(int invoiceID)
		{
			String sql = @"UPDATE `flowers_park`.`invoices` SET `inv_penalty`= 0 , `inv_penalty_is_paid`= 1 , `inv_penalty_date`= NULL  WHERE `id`=" + invoiceID + ";";

			executeQuery(sql);
		}

		public static void setNoReserve(int reserveID)
		{
			String sql = @"UPDATE `flowers_park`.`reserves` SET `app_id`= NULL, `reserve_ammount`= NULL WHERE `id`=" + reserveID + ";";

			executeQuery(sql);
		}


		public static DataTable getAppsReservedByClientID(int clientID)
		{
			String sql = "SELECT CONCAT(buildings.name,\"-\",floor_no, \"-\", app_no) AS appNo ," +
						" reserves.id , reserves.reserve_ammount " +
						@"FROM flowers_park.reserves , flowers_park.appartments , flowers_park.buildings
						where  reserves.app_id = appartments.id AND appartments.building_id = buildings.id
						AND reserves.client_id = " + clientID + "; ";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static double getReserveAmmount(int reserve_id)
		{
			String sql = @"SELECT reserve_ammount FROM flowers_park.reserves where id = " + reserve_id + ";";

			DataTable dt = getDataTable(sql);
			double reserveAmmount = 0;
			if (dt.Rows.Count > 0)
			{
				DataRow dataRow = dt.Rows[0];

				try
				{
					reserveAmmount = Convert.ToDouble(dataRow[dt.Columns.IndexOf("reserve_ammount")]);
				}
				catch (Exception ex)
				{

				}
			}

			return reserveAmmount;
		}

		public static DataTable getReserveInvoices(int reserve_id)
		{
			String sql = @"SELECT reserves_invoices.id as reserve_invoices_id,payment_date,ammount,reserves_invoices_types.type
						FROM flowers_park.reserves_invoices , flowers_park.reserves_invoices_types
						where reserves_invoices.reserve_type_id = reserves_invoices_types.id
						AND reserves_invoices.reserve_id = " + reserve_id + ";";

			DataTable dt = getDataTable(sql);

			return dt;
		}


		public static void insertReserveInvoice(String paymentDate, double ammount, int reserveID, int reserveTypeID)
		{
			String sql = @"INSERT INTO `flowers_park`.`reserves_invoices`
						(`payment_date`, `ammount`, `reserve_id`, `reserve_type_id`)
						VALUES ('" + paymentDate + "', '" + ammount + "', '" + reserveID + "', '" + reserveTypeID + "');";

			executeQuery(sql);
		}

		public static void deleteReserveInvoice(int invID)
		{
			String sql = @"DELETE FROM `flowers_park`.`reserves_invoices` WHERE `id`='" + invID + "';";

			executeQuery(sql);
		}

		public static DataTable getClientHistoryInvoices(int clientID)
		{
			String sql = "SELECT  CONCAT(buildings.name,\"-\",floor_no, \"-\", app_no) AS appNo  ," +
						 @"invoices.id as inv_id , invoices_types.inv_month , invoices_types.start_date
						, invoices_types.due_date , invoices.payment_date , invoices.ammount , flowers_park.invoices.inv_penalty
						FROM flowers_park.invoices , flowers_park.invoices_types , flowers_park.reserves
						, flowers_park.appartments , flowers_park.buildings
						where flowers_park.invoices.inv_type_id = flowers_park.invoices_types.id
						AND reserves.id = invoices.reserve_id AND appartments.id = reserves.app_id
						AND appartments.building_id = buildings.id AND reserves.client_id = " + clientID + " ; ";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getInvoiceByID(int invoice_id)
		{
			String sql = @"SELECT invoices.id , invoices_types.inv_month , invoices.inv_index ,
						invoices.ammount , clients.client_name , clients.client_file , invoices_types.start_date
						, buildings.name as building_name , appartments.floor_no ,appartments.app_no
						FROM flowers_park.invoices  , flowers_park.reserves , flowers_park.clients ,
						flowers_park.invoices_types , flowers_park.appartments , flowers_park.buildings
						where invoices.reserve_id = reserves.id AND reserves.client_id = clients.id
						AND invoices.inv_type_id = invoices_types.id AND appartments.id = reserves.app_id
						AND buildings.id = appartments.building_id
						AND invoices.id = " + invoice_id + " ;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getPrintInvoicesByClientID(int clientID)
		{
			String sql = @"SELECT invoices.id , invoices_types.inv_month , invoices.inv_index ,
						invoices.ammount , clients.client_name , clients.client_file , invoices_types.start_date
						, buildings.name as building_name , appartments.floor_no ,appartments.app_no
						FROM flowers_park.invoices  , flowers_park.reserves , flowers_park.clients ,
						flowers_park.invoices_types , flowers_park.appartments , flowers_park.buildings
						where invoices.reserve_id = reserves.id AND reserves.client_id = clients.id
						AND invoices.inv_type_id = invoices_types.id  AND appartments.id = reserves.app_id
						AND buildings.id = appartments.building_id
						AND reserves.client_id = " + clientID + " ;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getPrintInvoicesByApptID(int app_id)
		{
			String sql = @"SELECT invoices.id , invoices_types.inv_month , invoices.inv_index ,
						invoices.ammount , clients.client_name , clients.client_file , invoices_types.start_date
						, buildings.name as building_name , appartments.floor_no ,appartments.app_no
						FROM flowers_park.invoices  , flowers_park.reserves , flowers_park.clients ,
						flowers_park.invoices_types , flowers_park.appartments , flowers_park.buildings
						where invoices.reserve_id = reserves.id AND reserves.client_id = clients.id
						AND invoices.inv_type_id = invoices_types.id AND appartments.id = reserves.app_id
						AND buildings.id = appartments.building_id
						AND reserves.app_id = " + app_id + " ;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getPenaltyPrintPageDetails(int invoice_id)
		{
			String sql = @"SELECT invoices.id , invoices_types.inv_month , invoices.inv_penalty ,
						invoices.ammount , clients.client_name , clients.client_file , invoices_types.start_date
						, invoices_types.due_date , invoices.payment_date , buildings.name as building_name ,
						appartments.floor_no ,appartments.app_no
						FROM flowers_park.invoices  , flowers_park.reserves , flowers_park.clients ,
						flowers_park.invoices_types , flowers_park.appartments , flowers_park.buildings
						where invoices.reserve_id = reserves.id AND reserves.client_id = clients.id
						AND invoices.inv_type_id = invoices_types.id AND appartments.id = reserves.app_id
						AND buildings.id = appartments.building_id
						AND invoices.id = " + invoice_id + ";";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static int getNumberOfInvoices()
		{
			String sql = @"SELECT count(id) as count FROM flowers_park.invoices_types;";

			DataTable dt = getDataTable(sql);
			int count = -1;
			if (dt.Rows.Count > 0)
			{
				DataRow dataRow = dt.Rows[0];

				try
				{
					count = Convert.ToInt32(dataRow[dt.Columns.IndexOf("count")]);
				}
				catch (Exception ex)
				{

				}
			}

			return count;
		}

		public static DataTable getClientInfo(int clientID)
		{
			String sql = @"SELECT * FROM flowers_park.clients where id = " + clientID + ";";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DataTable getConfigs()
		{
			String sql = @"SELECT * FROM flowers_park.configurations where id = 1;";

			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static DateTime getCurrentDate()
		{
			String sql = @"select now() as date;";

			DataTable dt = getDataTable(sql);

			DataRow dr = dt.Rows[0];

			DateTime date = Convert.ToDateTime(dr[dt.Columns.IndexOf("date")]);

			return date;
		}


		public static DataTable getAllInvoicesTypes()
		{
			String sql = @"SELECT id , inv_month FROM flowers_park.invoices_types;";

			DataTable dt = getDataTable(sql);

			return dt;
		}
		*/

		#endregion

	}

}
