using Lab2.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Lab2.Repository
{
    public class CoolerRepository
    {
        public bool insertCooler(CoolerEditViewModel cooler)
        {

            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO aušintuvai(Pavadinimas, Paskirtis, Gamintojas, Ventiliatoriaus_dydis, 
                                   Max_apsukos, id_Aušintuvai, fk_CPUid_CPU) VALUES 
                                   (?Pavadinimas,?Paskirtis,?Gamintojas,?Ventiliatoriaus_dydis,?Max_apsukos,?id_Aušintuvai,?fk_CPUid_CPU);";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?Pavadinimas", MySqlDbType.VarChar).Value = cooler.Pavadinimas;
                mySqlCommand.Parameters.Add("?Paskirtis", MySqlDbType.VarChar).Value = cooler.Paskirtis;
                mySqlCommand.Parameters.Add("?Gamintojas", MySqlDbType.VarChar).Value = cooler.Gamintojas;
                mySqlCommand.Parameters.Add("?Ventiliatoriaus_dydis", MySqlDbType.VarChar).Value = cooler.Fan_size;
                mySqlCommand.Parameters.Add("?Max_apsukos", MySqlDbType.VarChar).Value = cooler.Max_RPM;
                mySqlCommand.Parameters.Add("?id_Aušintuvai", MySqlDbType.Int32).Value = cooler.id_Cooler;
                mySqlCommand.Parameters.Add("?fk_CPUid_CPU", MySqlDbType.Int32).Value = cooler.idCPU;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CoolerEditViewModel> GetCoolerEditViewModels(int Fid)
        {
            List<CoolerEditViewModel> coolers = new List<CoolerEditViewModel>();


            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.Pavadinimas, m.Paskirtis,m.Gamintojas,
            m.Ventiliatoriaus_dydis,m.Max_apsukos,m.id_Aušintuvai, m.fk_CPUid_CPU FROM aušintuvai m WHERE m.fk_CPUid_CPU=" + Fid;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                coolers.Add(new CoolerEditViewModel
                {
                    Pavadinimas = Convert.ToString(item["Pavadinimas"]),
                    Paskirtis = Convert.ToString(item["Paskirtis"]),
                    Gamintojas = Convert.ToString(item["Gamintojas"]),
                    Fan_size = Convert.ToString(item["Ventiliatoriaus_dydis"]),
                    Max_RPM = Convert.ToString(item["Max_apsukos"]),
                    id_Cooler = Convert.ToInt32(item["id_Aušintuvai"]),
                    idCPU = Convert.ToInt32(item["fk_CPUid_CPU"]),
                });
                


            }
            return coolers;
        }

        public void deleteCooler(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM aušintuvai where fk_CPUid_CPU=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        public bool updateCooler(CoolerEditViewModel cooler)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE aušintuvai a SET a.Pavadinimas=?Pavadinimas, a.Paskirtis=?Paskirtis,
                    a.Gamintojas=?Gamintojas, a.Ventiliatoriaus_dydis=?Ventiliatoriaus_dydis,
                    a.Max_apsukos=?Max_apsukos, a.fk_CPUid_CPU=?fk_CPUid_CPU 
                    WHERE a.id_Aušintuvai=?id_Aušintuvai;";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?Pavadinimas", MySqlDbType.VarChar).Value = cooler.Pavadinimas;
                mySqlCommand.Parameters.Add("?Paskirtis", MySqlDbType.VarChar).Value = cooler.Paskirtis;
                mySqlCommand.Parameters.Add("?Gamintojas", MySqlDbType.VarChar).Value = cooler.Gamintojas;
                mySqlCommand.Parameters.Add("?Ventiliatoriaus_dydis", MySqlDbType.VarChar).Value = cooler.Fan_size;
                mySqlCommand.Parameters.Add("?Max_apsukos", MySqlDbType.VarChar).Value = cooler.Max_RPM;
                mySqlCommand.Parameters.Add("?id_Aušintuvai", MySqlDbType.Int32).Value = cooler.id_Cooler;
                mySqlCommand.Parameters.Add("?fk_CPUid_CPU", MySqlDbType.Int32).Value = cooler.idCPU;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}