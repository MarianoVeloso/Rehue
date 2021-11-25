using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Reflection;
using System.IO;
using System.Data.SqlClient;
using System.Configuration.Install;
using System.Diagnostics;

namespace Rehue.Servicios
{
	public class SqlInstaller : Installer
	{
		private string logFilePath = "C:\\setupLog.txt";

		private string GetSql(string Name)
		{
			try
			{

				// Gets the current assembly.
				Assembly Asm = Assembly.GetExecutingAssembly();

				// Resources are named using a fully qualified name.
				Stream strm = Asm.GetManifestResourceStream(Asm.GetName().Name + "." + Name);

				// Reads the contents of the embedded file.
				StreamReader reader = new StreamReader(strm);

				return reader.ReadToEnd();
			}
			catch (Exception ex)
			{
				Log(ex.Message);
				throw ex;
			}
		}
		private void ExecuteSql(string serverName, string dbName, string Sql)
		{
			string connStr = "Data Source=" + serverName + ";Initial Catalog=" +
									dbName + ";Integrated Security=True";
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				try
				{
					Server server = new Server(new ServerConnection(conn.ConnectionString));
					server.ConnectionContext.ExecuteNonQuery(Sql);
				}
				catch (Exception ex)
				{
					Log(ex.Message);
				}
			}
		}
		protected void AddDBTable(string serverName)
		{
			try
			{
				// Creates the database and installs the tables.         
				string strScript = GetSql("sql.txt");
				ExecuteSql(serverName, "master", strScript);
			}
			catch (Exception ex)
			{
				//Reports any errors and abort.
				Log(ex.Message);
				throw ex;
			}
		}

		/// <summary>
		/// Launch the application with some options set.
		/// </summary>
		static void LaunchCommandLineApp()
		{
			// For the example
			const string ex1 = "C:\\";
			const string ex2 = "C:\\Dir";

			// Use ProcessStartInfo class
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.CreateNoWindow = false;
			startInfo.UseShellExecute = false;
			startInfo.FileName = "dcm2jpg.exe";
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y " + ex2;

			try
			{
				// Start the process with the info we specified.
				// Call WaitForExit and then the using statement will close.
				using (Process exeProcess = Process.Start(startInfo))
				{
					exeProcess.WaitForExit();
				}
			}
			catch
			{
				// Log error.
			}
		}

		public override void Install(System.Collections.IDictionary stateSaver)
		{
			base.Install(stateSaver);
			Log("Setup started");
			AddDBTable(this.Context.Parameters["servername"]);

		}
		public void Log(string str)
		{
			StreamWriter Tex;
			try
			{
				Tex = File.AppendText(this.logFilePath);
				Tex.WriteLine(DateTime.Now.ToString() + " " + str);
				Tex.Close();
			}
			catch
			{

			}
		}
	}
}
