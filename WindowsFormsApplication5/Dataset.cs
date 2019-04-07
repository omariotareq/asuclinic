
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

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
					myBuilder.MultipleActiveResultSets = true;
					

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

		internal struct ReturnValues
		{
			public long usrId;
			public string usrAccess;
		}
		#region Ehna
		public static  ReturnValues getUserID(String username, String Password)    //loginform
		{
			ReturnValues rv = new ReturnValues();

			String sql = @"select login.id,login.access as id,access  from asudb.dbo.login
						   where login.username = '" + username + "' AND login.password = '" + Password + "';";

			DataTable dt = getDataTable(sql);

			if (dt.Rows.Count > 0)
			{
				DataRow dataRow = dt.Rows[0];

				
				

				 rv.usrId = Convert.ToInt32(dataRow[dt.Columns.IndexOf("id")]);

				 rv.usrAccess = Convert.ToString(dataRow[dt.Columns.IndexOf("access")]);

				return rv;



			}
			else
			{
				rv.usrId = 0; // wrong user or password
				return rv;
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

		public static void InsertNewUser(string un,string pw,string access)
		{

			String sql = @"INSERT INTO  asudb.dbo.Login (username,password,access) VALUES ('" + un + "','" + pw + "','"+ access +"' )";
			executeQuery(sql);


		}
		public static DataTable SelectAllUsers()
		{
			String sql = @"SELECT * FROM asudb.dbo.Login ";
			DataTable dt = getDataTable(sql);

			return dt;
		}

		public static void ModifyAccess(string access,string username,string password,int id)
		{
			String sql = @"UPDATE asudb.dbo.Login SET access= '"+access + "',username='"+username+ "',password='"+password+ "' WHERE id='"+id+"' ";
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

		public static DataTable getPatientInfo(int id)
		{
			String sql = @"SELECT * FROM asudb.dbo.personal_info WHERE id= '" +id+"'";

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
		public static void Updatelabentery(DateTime labdat, string hb, string hema, string mcv, string rdw, string latlets, string tlc, string neuro, string lym, string ceos, string seriron, string tibc, string serumfe, string ESR, string CRP, string ANCA, string ASCA, string fecacal, string TTG, string ARBCs, string puscells, string clodef, int para, string toolscs, String paranotes, String othernotes, string tt, int tp, String Qua, int HB, int HBV, int HC, int HIV, string Am, string LI, string NA, string K, string Ca, string Mg, string ph, string FALT, string FAST, string FTP, string FAlb, string fdb, string ftb, string FALP, string FFGT, string INR, string SCreat, string BUn, string otherdetails, int p_id,int id ,string LARFib)
		{

string sql=	@"UPDATE asudb.dbo.labentery
   SET
	[labdate]			= '" + labdat + @"'
	  ,[cbchema]			= '" +hema+@"'
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

		 WHERE p_id ='"+p_id+ "'AND  id='"+id+"'";


		executeQuery(sql);
			//27/2
}
		public static int InsertenterographyyInfo(DateTime date, string enst, int musleh, string jeE, string ilE, string RcE, string TcE, string LcE, string ScE, string ReE, int Msl, int subdema, string jedema, string ildema, string Rcdema, string Tcdema, string Lcdema, string Scdema, string Redema, int muralab, string jela, string illa, string Rcla, string Tcla, string Lcla, string Scla, string Rela, string jemt, string ilmt, string Rcmt, string Tcmt, string Lcmt, string Scmt, string Remt, int fd, int cs, int mf, string jens, string ilns, string Rcns, string Tcns, string Lcns, string Scns, string Rens, int presd, string jep, string ilp, string Rcp, string Tcp, string lcp, string Scp, string Rep, int Lh, string ttl, int cf, int caf, string clot, string cdab, string cdot, string cdvt, string ctof, string cabs, string cttf, string comother, string oth, string enter, int p_id)
		{

			String sql = @"INSERT INTO asudb.dbo.enterography
		   (date,Entrostudy,mucosalenh,jejEa,ilEa,RcEa,TcEa,LcEa,ScEa,ReEa,Mucosalirrefi,submucosaledema,jethofSMedema,ilthofSMedema ,RcthofSMedema,TcthofSMedema ,LcthofSMedema ,ScthofSMedema,RethofSMedema,muralabscess,jelengthactivity,illengthactivity  ,Rclengthactivity   ,Tclengthactivity  ,Lclengthactivity    ,Sclengthactivity,Relengthactivity,jemuralthickness,ilmuralthickness,Rcmuralthickness,Tcmuralthickness    ,Lcmuralthickness  ,Scmuralthickness   ,Remuralthickness   ,Fatedema   ,combsign,Muralfib,jeNarstr,ilNarstr ,RcNarstr,TcNarstr,LcNarstr ,ScNarstr  ,ReNarstr  ,Prestenoticdial,jePrestenoticdiam,ilPrestenoticdiam  ,RcPrestenoticdiam ,TcPrestenoticdiam  ,LcPrestenoticdiam,ScPrestenoticdiam  ,RePrestenoticdiam ,LossofHaus,totallength  ,compfistula  ,compAbscessformation  ,complenoftrack,compdiamofab,compdiamoftrack,compvolofab,comptypeoffistula,compabsloc,compothertypefis,compotherabsloc,otherentrofindings ,EntroReport ,p_id)  OUTPUT INSERTED.id as id

			   VALUES ('" + date + "',' " + enst + "','" + musleh + "','" + jeE + "','" + ilE + "','" + RcE + "', '" + TcE + "','" + LcE + "','" + ScE + "','" + ReE + "','" + Msl + "','" + subdema + "', '" + jedema + "', '" + ildema + "', '" + Rcdema + "', '" + Tcdema + "', '" + Lcdema + "', '"+Scdema+"','" + Redema+ "' ,'" + muralab + "', '" + jela + "' ,'" + illa + "' ,'" + Rcla + "' ,'" + Tcla + "','" + Lcla+ "','" + Scla + "','" + Rela + "','" + jemt + "','" + ilmt + "','" + Rcmt + "','" + Tcmt + "','" + Lcmt + "','" + Scmt + "','" + Remt + "' ,'" + fd + "' ,'" + cs + "' ,'" + mf + "' ,'" + jens + "' ,'" + ilns + "' ,'" + Rcns + "' ,'" + Tcns + "','" + Lcns + "' ,'" + Scns + "' ,'" + Rens + "' ,'" + presd + "' ,'" + jep + "','" + ilp + "' ,'" + Rcp + "' ,'" + Tcp + "' ,'" + lcp + "' ,'" + Scp + "' ,'" + Rep + "','"+Lh+"', '" + ttl + "', '" + cf + "', '" + caf + "', '" + clot + "', '" + cdab + "', '" + cdot + "', '" + cdvt + "', '" + ctof + "', '" + cabs + "', '" + cttf + "', '" + comother + "', '" + oth + "', '" + enter+ "','" + p_id + "' )";


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
			string sql = @"SELECT * FROM asudb.dbo.u_images WHERE u_id='" + p_id + "'";
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




	    public static DataTable getUserData(int id)
	    {
	        string sql = @"SELECT * FROM asudb.dbo.Login WHERE id='" + id + "'";
	        DataTable dt = getDataTable(sql);

	        return dt;
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

		public static void parametrizedInsertEndo(int e_id, byte[] image)
		{

			string sql = "INSERT INTO  asudb.dbo.endo_images (endo_id,endo_image) VALUES  (@id,@img);";

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

		public static void parametrizedInsertPath(int e_id, byte[] image)
		{

			string sql = "INSERT INTO  asudb.dbo.path_images (path_id,path_image) VALUES  (@id,@img);";

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

		public static DataTable selectEndoImages(int e_id)
		{

			string sql = @"SELECT * FROM asudb.dbo.endo_images WHERE endo_id='" + e_id + "' ";
			DataTable dt = getDataTable(sql);
			return dt;
		}

		public static DataTable selectPathImages(int e_id)
		{

			string sql = @"SELECT * FROM asudb.dbo.path_images WHERE path_id='" + e_id + "' ";
			DataTable dt = getDataTable(sql);
			return dt;
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
				"eryl ='" + eryl + "', erytr='" + erytr + "', " + "eryrt='" + eryrt + "', eryti='" + eryti + "', " +"eryn='" + eryn +  "', vr='" + vr + "', vs='" + vs + "', vl='" + vl + "', vtr='" + vtr + "', vrt='" + vrt + "', vti='" + vti + "', vn='" + vn + "', ur='" + ur + "', us='" + us + "', ul='" + ul + "', utr='" + utr + "', urt='" + urt + "', uti='" + uti + "', un='" + un + "', usr='" + usr + "', uss='" + uss + "', usl='" + usl + "', ustr='" + ustr + "', usrt='" + usrt + "', usti='" + usti + "', usn='" + usn + "', uar='" + uar + "', uas='" + uas + "',ual='" + ual + "', uatr='" + uatr + "', uart='" + uart + "', uati='" + uati + "', uan='" + uan + "', Muscoalero='" + Muscoalero + "', Muscoalfria='" + Muscoalfria + "', Nr='" + Nr + "', Ns='" + Ns + "', Nl='" + Nl + "', Ntr='" + Ntr + "', Nrt='" + Nrt + "', Nti='" + Nti + "', Nn='" + Nn + "', Pancolitis='" + Pancolitis + "'WHERE p_id='" + pid + "' And id='" + id + "';";

			executeQuery(sql);
		}
		//11/3/2019
		public static void Updatepatholgydata(DateTime date, string il, string ilad, string ilc, string nii, string Er, int uc, int gra, string other, string irco, string cradc, string balco, string cry, string lamin, int lamen, int ulceo, int gran, string otherfind, string finalreport, int pid,int id)
		{
			string sql = @"UPDATE asudb.dbo.pathology SET patholgydate='" + date + "'" +
			", ileir='" + il + "', ilad='" + ilad + "', ilic='" + ilc + "', " +
			" Niil ='" + nii + "', ilER='" + Er + "', " + "ucil='" + uc + "', grail='" + gra + "', " + "otherileal='" + other + "', irco='" + irco + "', cradco='" + cradc + "', balco='" + balco + "', crycco='" + cry + "', lamineosco='" + lamin + "', lamneutroco='" + lamen + "', ulceco='" + ulceo + "', granilco='" + gran + "', otherfindings='" + otherfind + "', finalreport='" + finalreport + "'WHERE p_id='" + pid + "' And id='" + id + "';";

			executeQuery(sql);
		}
		//3/11/2019
		public static void UpdateSurgeryInfo(DateTime ds, string si, string opd, string sc, int pid,int id)
		{



			string sql = @"UPDATE asudb.dbo.surgery SET Dateofsurgery='" + ds + "'" +
			", surgicalindication='" + si + "', operativedetails='" + opd + "', surgicalcomplication='" + sc + "' WHERE p_id='" + pid + "' And id='" + id + "';";

			executeQuery(sql);
		}

		public static void Updatedruginfo(DateTime Rd, int sterodate, string dose, string weekno, string sternotes, int Asas, string Asad, string Asaw, int Asao, string Asaod, string Asaow, int Asar, string Asard, string Asarw, int immmtx, string immmd, string immmw, int imma, string immad, string immaw, int bif, string bifd, string bifw, int bad, string badd, string badw, int bgo, string bgod, string bgow, int bus, string busd, string busw, string Biolgnotes, int supvit, int supca, int supppi, int suppfa, int suppiron, string suproute, string supdose, int antiat, string antidetails, string othermedication, int p_id, int id)
		{
			string sql = @"UPDATE asudb.dbo.druglist SET Recorddate='" + Rd + "'" +
		", steroidtreat='" + sterodate + "', Dose ='" + dose + "', Wekkno='" + weekno + "'" +
		",Steroidsnotes='" + sternotes + "', Asas='" + Asas + "', " + "Asad='" + Asad + "', Asaw='" + Asaw + "', " + "Asao='" + Asao + "', Asaod='" + Asaod + "', Asaow='" + Asaow + "', Asar='" + Asar + "', Asard='" + Asard + "', Asarw='" + Asarw + "', immmtx='" + immmtx + "', immmd='" + immmd + "', immmw='" + immmw + "', imma='" + imma + "', immad='" + immad + "',immaw='" + immaw + "',    bif='" + bif + "',    bifd='" + bifd + "',    bifw='" + bifw + "',    bad='" + bad + "',    badd='" + badd + "',    badw='" + badw + "',    bgo='" + bgo + "',    bgod='" + bgod + "',    bgow='" + bgow + "',    bus='" + bus + "',    busd='" + busd + "',    busw='" + busw + "',    Biolgnotes='" + Biolgnotes + "',    supvit='" + supvit + "',  supca='" + supca + "',  supppi='" + supppi + "',  suppfa='" + suppfa + "',  suppiron='" + suppiron + "',  suproute='" + suproute + "',  antiat='" + antiat + "', antidetails='" + antidetails + "',  othermedication='" + othermedication + "'WHERE p_id='" + p_id + "' And id='" + id + "';";

			executeQuery(sql);

		}
		public static void  Updateultrasonicinfo(int uscheck, DateTime date, string moje, string moil, string moRc, string moTc, string moLc, string moSi, int subed, string smtje, string smtil, string smtRc, string smtTc, string smtLc, string smtSi, string slje, string slil, string slRc, string slTc, string slLc, string slSi, string mtje, string mtil, string mtrc, string mttc, string mtlc, string mtsi, string mhje, string mhil, string mhrc, string mhtc, string mhlc, string mhsi, string mpje, string mpil, string mprc, string mptc, string mplc, string mpsi, string mrje, string mril, string mrrc, string mrtc, string mrlc, string mrsi, string mpije, string mpiil, string mpirc, string mpitc, string mpilc, string mpisi, int fat, int local, string llsj, string llsi, string llsrc, string llstc, string llslc, string llssi, string llvj, string llvi, string llvrc, string llvtc, string llvlc, string llvsi, int muralfib, int luminalstric, int pres, string jdiam, string idiam, string rtcdiam, string trcdiam, string ltcdiam, string sigcdiam, string tl, int pof, string leng, string fis_dia, string type, string othertypefis, int pa, string dia, string vol, string loa, string otherlloac, string oth, string ultra, int p_id,int id)
		{
			string sql = @"UPDATE asudb.dbo.ultrasonicradio SET ultrasoniccheck='" + uscheck + "'" +
				  ", Dateofus='" +date + "', moje ='" + moje + "', moil='" + moil + "'" +
			   ",morc='" + moRc + "', motc='" + moTc + "', " + "molc='" + moLc + "',mosi ='" + moSi + "', " + "subedema='" + subed + "', smtje='" + smtje + "', smtil='" + smtil + "', smtrc='" + smtRc + "', smttc='" + smtTc + "',smtlc ='" + smtLc + "', smtsi='" + smtSi + "', slje='" + slje + "', slil='" + slil + "', slrc='" + slRc + "', sltc='" + slTc + "',sllc='" + slLc + "',    slsi='" + slSi + "',    mtje='" + mtje + "',    mtil='" + mtil + "',    mtrc='" + mtrc + "',   mttc='" + mttc + "',    mtlc='" + mtlc + "',    mtsi='" + mtsi + "',    mhje='" + mhje + "',  mhil='" + mhil + "',  mhrc='" + mhrc + "',    mhtc='" + mhtc + "',    mhlc='" + mhlc + "',    mhsi='" + mhsi + "',    mpje='" + mpje + "',    mpil='" + mpil + "',  mprc='" + mprc + "',  mptc='" + mptc + "',  mplc='" + mplc + "',  mpsi='" + mpsi + "',  mrje='" + mrje + "',  mril='" + mril + "', mrrc='" + mrrc + "',  mrtc='" + mrtc + "', mrlc='" + mrlc + "', mrsi='" + mrsi + "', mpije='" + mpije + "', mpiil='" + mpiil + "', mpirc='" + mpirc + "', mpitc='" + mpitc + "', mpilc='" + mpilc + "', mpisi='" + mpisi + "', fatcreepsign='" + fat + "', locallnenla='" + local + "', llsje='" + llsj + "', llsil='" + llsi + "', llsrc='" + llsrc + "', llstc='" + llstc + "', llslc='" + llslc + "', llssi='" + llssi + "', llvje='" + llvj + "', llvil='" + llvi+ "', llvrc='" + llvrc + "', llvtc='" + llvtc + "', llvlc='" + llvlc + "', llvsi='" + llvsi + "', muralfib='" + muralfib + "', luminalstric='" + luminalstric + "', presdialation='" + pres + "', jejuPresDiam='" + jdiam + "', ileumPresDiam='" + idiam + "', rtColonPresDiam='" + rtcdiam + "', trColonPresDiam='" + trcdiam + "', ltColonPresDiam='" + ltcdiam + "', sigColonPresDiam='" + sigcdiam + "', tcl='" + tl + "', pof='" + pof + "', length='" + leng + "', fis_diameter='" + fis_dia + "', typeoffis='" + type + "', othertypefis='" + othertypefis + "', pa='" + pa + "', Diam='" + dia + "', volume='" + vol + "', loa='" + loa + "', otherlloac='" + otherlloac + "',  otherfinding='" + oth + "', ultrasoundreport='" + ultra + "'WHERE p_id='" + p_id + "' And id='" + id + "';";

			executeQuery(sql);
		}
		public static void UpdateUserInfo(string f, string m, string l, string t, string g, int age, string address, string city, string governorate, string occu, string mari, string menst, DateTime fv,int id)
		{



			string sql = @"UPDATE asudb.dbo.personal_info SET fname= '" + f + "'" +
				  ", mname='" + m + "', lname ='" + l + "', tele='" + t + "'" +
			   ",gender='" + g + "', age='" + age + "', " + "adress='" + address + "',city ='" + city + "', " + "governorate='" + governorate + "', occupation='" + occu + "', maritialstatus='" + mari + "', mensturalhistory='" + menst + "' where id='" + id + "';";
			executeQuery(sql);
		}

		public static void UpdateenterographyyInfo(DateTime date, string enst, int musleh, string jeE, string ilE, string RcE, string TcE, string LcE, string ScE, string ReE, int Msl, int subdema, string jedema, string ildema, string Rcdema, string Tcdema, string Lcdema, string Scdema, string Redema, int muralab, string jela, string illa, string Rcla, string Tcla, string Lcla, string Scla, string Rela, string jemt, string ilmt, string Rcmt, string Tcmt, string Lcmt, string Scmt, string Remt, int fd, int cs, int mf, string jens, string ilns, string Rcns, string Tcns, string Lcns, string Scns, string Rens, int presd, string jep, string ilp, string Rcp, string Tcp, string lcp, string Scp, string Rep, int Lh, string ttl, int cf, int caf, string clot, string cdab, string cdot, string cdvt, string ctof, string cabs, string cttf, string comother, string oth, string enter, int p_id,int id)
		{
			string sql = @"UPDATE asudb.dbo.enterography SET date='" + date + "'" +
			  ", Entrostudy='" + enst + "', mucosalenh ='" + musleh + "', jejEa='" + jeE + "'" +
		   ",ilEa='" + ilE + "', RcEa='" + RcE + "', " + "TcEa='" + TcE + "',LcEa ='" + LcE + "', " + "ScEa='" + ScE + "', ReEa='" + ReE + "', Mucosalirrefi='" + Msl + "', submucosaledema='" + subdema + "', jethofSMedema='" + jedema + "',ilthofSMedema ='" + ildema + "', RcthofSMedema='" + Rcdema + "', TcthofSMedema='" + Tcdema+ "', LcthofSMedema='" + Lcdema + "', ScthofSMedema='" + Scdema + "', RethofSMedema='" + Redema + "',muralabscess='" + muralab+ "',  jelengthactivity='" + jela + "',    illengthactivity='" + illa + "',    Rclengthactivity='" + Rcla + "',    Tclengthactivity='" + Tcla + "',   Lclengthactivity='" + Lcla + "',    Sclengthactivity='" +Scla + "',    Relengthactivity='" + Rela + "',    jemuralthickness='" + jemt + "',  ilmuralthickness='" + ilmt + "',  Rcmuralthickness='" + Rcmt + "',    Tcmuralthickness='" + Tcmt + "',    Lcmuralthickness='" + Lcmt + "',    Scmuralthickness='" + Scmt + "',    Remuralthickness='" + Remt + "',    Fatedema='" + fd + "',  combsign='" + cs + "',  Muralfib='" + mf + "',  jeNarstr='" + jens + "',  ilNarstr='" + ilns + "',  RcNarstr='" +Rcns + "',  TcNarstr='" + Tcns + "', LcNarstr='" + Lcns + "',  ScNarstr='" + Scns + "', ReNarstr='" + Rens + "', Prestenoticdial='" + presd + "', jePrestenoticdiam='" + jep + "', ilPrestenoticdiam='" + ilp + "', RcPrestenoticdiam='" + Rcp + "', TcPrestenoticdiam='" + Tcp + "', LcPrestenoticdiam='" + lcp + "', ScPrestenoticdiam='" + Scp + "', RePrestenoticdiam='" + Rep+ "', LossofHaus='" + Lh + "',totallength='" + ttl+ "', compfistula='" + cf+ "', compAbscessformation='" + caf + "', complenoftrack='" + clot + "', compdiamofab='" + cdab + "', compdiamoftrack='" + cdot + "', compvolofab='" + cdvt+ "', comptypeoffistula='" + ctof + "', compabsloc='" + cabs+ "', compothertypefis='" + cttf + "', compotherabsloc='" + comother + "', otherentrofindings='" + oth + "', EntroReport='" + enter + "'WHERE p_id='" + p_id + "' And id='" + id + "';";

			executeQuery(sql);
		}


		public static void deletePatients(int id)
		{
			String sql = "DELETE FROM asudb.dbo.personal_info  WHERE id='" + id + "';";

			executeQuery(sql);
		}

		public static void deletesurgery(int id,int pid)
		{
			String sql = "DELETE FROM asudb.dbo.surgery  WHERE id='" + id + "' And p_id='" + pid + "';";

			executeQuery(sql);
		}

		public static void deletelabentery(int id, int pid)
		{
			String sql = "DELETE FROM asudb.dbo.labentery  WHERE id='" + id + "' And p_id='" + pid + "';";

			executeQuery(sql);
		}

		public static void deletedruglist(int id, int pid)
		{
			String sql = "DELETE FROM asudb.dbo.druglist  WHERE id='" + id + "' And p_id='" + pid + "';";

			executeQuery(sql);
		}
		public static void deleteActionplan(int id, int pid)
		{
			String sql = "DELETE FROM asudb.dbo.Actionplan  WHERE id='" + id + "' And p_id='" + pid + "';";

			executeQuery(sql);
		}
		public static void deleteEndoscopy(int id, int pid)
		{
			String sql = "DELETE FROM asudb.dbo.Endoscopy  WHERE id='" + id + "' And p_id='" + pid + "';";

			executeQuery(sql);
		}
		public static void deleteEntero(int id, int pid)
		{
			String sql = "DELETE FROM asudb.dbo.enterography  WHERE id='" + id + "' And p_id='" + pid + "';";

			executeQuery(sql);
		
		}

		public static void deleteExam(int id, int pid)
		{
			String sql = "DELETE FROM asudb.dbo.Exam_details WHERE id='" + id + "' And p_id='" + pid + "';";

			executeQuery(sql);
		}
		public static void deletehistory(int id, int pid)
		{
			String sql = "DELETE FROM asudb.dbo.History  WHERE id='" + id + "' And p_id='" + pid + "';";

			executeQuery(sql);

		}
		public static void deleteultrasonic(int id, int pid)
		{
			String sql = "DELETE FROM asudb.dbo.ultrasonicradio  WHERE id='" + id + "' And p_id='" + pid + "';";

			executeQuery(sql);
		}
		public static void deletepathology(int id, int pid)
		{
			String sql = "DELETE FROM asudb.dbo.pathology  WHERE id='" + id + "' And p_id='" + pid + "';";

			executeQuery(sql);
		}

		public static void deleteuimages(int id, int pid)
		{
			String sql = "DELETE FROM asudb.dbo.u_images  WHERE id='" + id + "';";

			executeQuery(sql);
		}

		public static void deleteenteroimages(int id, int pid)
		{
			String sql = "DELETE FROM asudb.dbo.imageentro  WHERE id='" + id + "' ;";

			executeQuery(sql);
		}

		public static void deleteEndoImage(int id, int pid)
		{
			String sql = "DELETE  FROM asudb.dbo.endo_images  WHERE id='" + id + "' ;";

			executeQuery(sql);
		}



		public static void deletePathImage(int id, int pid)
		{
			String sql = "DELETE  FROM asudb.dbo.path_images  WHERE id='" + id + "' ;";

			executeQuery(sql);
		}



	    public static void deleteUser(int id)
	    {
	        String sql = "DELETE  FROM asudb.dbo.Login  WHERE id='" + id + "' ;";

	        executeQuery(sql);
	    }











		#endregion

	}

}
