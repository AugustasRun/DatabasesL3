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
    public class CpuRepository
    {
        public List<CpuViewModel> getCPUs()
        {

            List<CpuViewModel> cpuViewModels = new List<CpuViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.Pavadinimas, m.Daznis,m.Vatai_suvartojimas,
            m.Pagreitintas_dažnis,m.Gamintojas,m.id_CPU, mm.pavadinimas AS motinine_plokste 
            FROM cpu m LEFT JOIN motinine_plokste mm ON 
            m.fk_Motinine_Ploksteid_Motinine_Plokste=mm.id_Motinine_Plokste";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                string temp = string.Empty;
                if (Convert.ToInt32(item["Gamintojas"]) == 1)
                {
                    temp = "Intel";
                }
                else
                {
                    temp = "AMD";
                }

                cpuViewModels.Add(new CpuViewModel
                {
                    Pavadinimas = Convert.ToString(item["Pavadinimas"]),
                    Daznis = Convert.ToString(item["Daznis"]),
                    Vatai = Convert.ToString(item["Vatai_suvartojimas"]),
                    Boost = Convert.ToString(item["Pagreitintas_dažnis"]),
                    Manufacturer = temp, 
                    id_CPU = Convert.ToInt32(item["id_CPU"]),
                    idMotherboard = Convert.ToString(item["motinine_plokste"]),


                });
            }
            return cpuViewModels;
        }


        public CpuEditViewModel getCPU(int id)
        {

            CpuEditViewModel cpuViewModel = new CpuEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.Pavadinimas, m.Daznis,m.Vatai_suvartojimas,
            m.Pagreitintas_dažnis,m.Gamintojas,m.id_CPU, m.fk_Motinine_Ploksteid_Motinine_Plokste FROM cpu m WHERE m.id_CPU=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
               
                cpuViewModel.Pavadinimas = Convert.ToString(item["Pavadinimas"]);
                cpuViewModel.Daznis = Convert.ToString(item["Daznis"]);
                cpuViewModel.Vatai = Convert.ToString(item["Vatai_suvartojimas"]);
                cpuViewModel.Boost = Convert.ToString(item["Pagreitintas_dažnis"]);
                cpuViewModel.Manufacturer = Convert.ToInt32(item["Gamintojas"]);
                cpuViewModel.id_CPU = Convert.ToInt32(item["id_CPU"]);
                cpuViewModel.idMotherboard = Convert.ToString(item["fk_Motinine_Ploksteid_Motinine_Plokste"]);


            }
            return cpuViewModel;
        }

        public bool insertCPU(CpuEditViewModel cpu)
        {

            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO cpu(Pavadinimas, Daznis, Vatai_suvartojimas, Pagreitintas_dažnis, Gamintojas, id_CPU, fk_Motinine_Ploksteid_Motinine_Plokste) 
                                    VALUES (?Pavadinimas,?Daznis,?Vatai_suvartojimas,?Pagreitintas_dažnis,?Gamintojas,?id_CPU,?fk_Motinine_Ploksteid_Motinine_Plokste);";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?Pavadinimas", MySqlDbType.VarChar).Value = cpu.Pavadinimas;
                mySqlCommand.Parameters.Add("?Daznis", MySqlDbType.VarChar).Value = cpu.Daznis;
                mySqlCommand.Parameters.Add("?Vatai_suvartojimas", MySqlDbType.VarChar).Value = cpu.Vatai;
                mySqlCommand.Parameters.Add("?Pagreitintas_dažnis", MySqlDbType.VarChar).Value = cpu.Daznis;
                mySqlCommand.Parameters.Add("?Gamintojas", MySqlDbType.Int32).Value = cpu.Manufacturer;
                mySqlCommand.Parameters.Add("?id_CPU", MySqlDbType.Int32).Value = cpu.id_CPU;
                mySqlCommand.Parameters.Add("?fk_Motinine_Ploksteid_Motinine_Plokste", MySqlDbType.Int32).Value = cpu.idMotherboard;
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


        public bool updateCPU(CpuEditViewModel cpu)
        {

            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE cpu a SET a.Pavadinimas=?Pavadinimas, a.Daznis=?Daznis,
                    a.Vatai_suvartojimas=?Vatai_suvartojimas, a.Pagreitintas_dažnis=?Pagreitintas_dažnis,
                    a.Gamintojas=?Gamintojas, a.fk_Motinine_Ploksteid_Motinine_Plokste=?fk_Motinine_Ploksteid_Motinine_Plokste 
                    WHERE a.id_CPU=?id_CPU";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?Pavadinimas", MySqlDbType.VarChar).Value = cpu.Pavadinimas;
                mySqlCommand.Parameters.Add("?Daznis", MySqlDbType.VarChar).Value = cpu.Daznis;
                mySqlCommand.Parameters.Add("?Vatai_suvartojimas", MySqlDbType.VarChar).Value = cpu.Vatai;
                mySqlCommand.Parameters.Add("?Pagreitintas_dažnis", MySqlDbType.VarChar).Value = cpu.Daznis;
                mySqlCommand.Parameters.Add("?Gamintojas", MySqlDbType.Int32).Value = cpu.Manufacturer;
                mySqlCommand.Parameters.Add("?id_CPU", MySqlDbType.Int32).Value = cpu.id_CPU;
                mySqlCommand.Parameters.Add("?fk_Motinine_Ploksteid_Motinine_Plokste", MySqlDbType.Int32).Value = cpu.idMotherboard;
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

        public void deleteCPU(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM cpu where id_CPU=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

       



    }
}