using Lab2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Lab2.Repository
{
    public class MotherboardRepository
    {
        public List<Motherboard> GetMotherboards()
        {
            List<Motherboard> motherboards = new List<Motherboard>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "SELECT * FROM motinine_plokste";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                int? temp = null;

                if (!Convert.IsDBNull(item["M2_NVEM_lizdai"]))
                {
                    temp = Convert.ToInt32(item["M2_NVEM_lizdai"]);
                }
                else
                {
                    temp = null;
                }


                motherboards.Add(new Motherboard
                {
                    Pavadinimas = Convert.ToString(item["Pavadinimas"]),
                    Dydis = Convert.ToString(item["Dydis"]),
                    Cpu_Tipas = Convert.ToString(item["CPU_tipas"]),
                    USB_ivestys = Convert.ToInt32(item["USB_Ivestys"]),
                    Ram_Lizdai = Convert.ToInt32(item["Ram_Lizdai"]),
                    Pcie_Lizdai = Convert.ToInt32(item["PCIe_lizdai"]),
                    M2_NVEM_Lizdai = temp,
                    id_Motinine_Plokste = Convert.ToInt32(item["id_Motinine_Plokste"])
                });
            }
            return motherboards;

        }
        public Motherboard GetMotherboard(int? id)
        {
            Motherboard motherboard = new Motherboard();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "SELECT * FROM motinine_plokste where id_Motinine_Plokste=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {

                motherboard.Pavadinimas = Convert.ToString(item["Pavadinimas"]);
                motherboard.Dydis = Convert.ToString(item["Dydis"]);
                motherboard.Cpu_Tipas = Convert.ToString(item["CPU_tipas"]);
                motherboard.USB_ivestys = Convert.ToInt32(item["USB_Ivestys"]);
                motherboard.Ram_Lizdai = Convert.ToInt32(item["Ram_Lizdai"]);
                motherboard.Pcie_Lizdai = Convert.ToInt32(item["PCIe_lizdai"]);
                if (!Convert.IsDBNull(item["M2_NVEM_lizdai"]))
                {
                    motherboard.M2_NVEM_Lizdai = Convert.ToInt32(item["M2_NVEM_lizdai"]);
                }
                else
                {
                    motherboard.M2_NVEM_Lizdai = null;
                }

                motherboard.id_Motinine_Plokste = Convert.ToInt32(item["id_Motinine_Plokste"]);
                
            }
            return motherboard;

        }



        public bool updateMotherboard(Motherboard Motherboard)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE "+ "motinine_plokste a SET a.Pavadinimas=?Name, " +
                    "a.Dydis=?size, a.CPU_tipas=?CPU, a.USB_Ivestys=?USB, " +
                    "a.Ram_lizdai=?Ram, a.PCIe_lizdai=?PCIe," +
                    "a.M2_NVEM_lizdai=?M2_NVEM  WHERE a.id_Motinine_Plokste=?id";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?Name", MySqlDbType.VarChar).Value = Motherboard.Pavadinimas;
                mySqlCommand.Parameters.Add("?size", MySqlDbType.VarChar).Value = Motherboard.Dydis;
                mySqlCommand.Parameters.Add("?CPU", MySqlDbType.VarChar).Value = Motherboard.Cpu_Tipas;
                mySqlCommand.Parameters.Add("?USB", MySqlDbType.VarChar).Value = Motherboard.USB_ivestys;
                mySqlCommand.Parameters.Add("?Ram", MySqlDbType.VarChar).Value = Motherboard.Ram_Lizdai;
                mySqlCommand.Parameters.Add("?PCIe", MySqlDbType.VarChar).Value = Motherboard.Pcie_Lizdai;
                mySqlCommand.Parameters.Add("?M2_NVEM", MySqlDbType.VarChar).Value = Motherboard.M2_NVEM_Lizdai;
                mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = Motherboard.id_Motinine_Plokste;
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

        public bool addMotherboard(Motherboard Motherboard)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO " + "motinine_plokste(Pavadinimas,Dydis," +
                    "CPU_tipas,USB_Ivestys,Ram_lizdai,PCIe_lizdai,M2_NVEM_lizdai,id_Motinine_Plokste)VALUES" +
                    "(?Name,?size,?CPU,?USB,?Ram,?PCIe,?M2_NVEM,?id);";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?Name", MySqlDbType.VarChar).Value = Motherboard.Pavadinimas;
                mySqlCommand.Parameters.Add("?size", MySqlDbType.VarChar).Value = Motherboard.Dydis;
                mySqlCommand.Parameters.Add("?CPU", MySqlDbType.VarChar).Value = Motherboard.Cpu_Tipas;
                mySqlCommand.Parameters.Add("?USB", MySqlDbType.Int32).Value = Motherboard.USB_ivestys;
                mySqlCommand.Parameters.Add("?Ram", MySqlDbType.Int32).Value = Motherboard.Ram_Lizdai;
                mySqlCommand.Parameters.Add("?PCIe", MySqlDbType.Int32).Value = Motherboard.Pcie_Lizdai;
                mySqlCommand.Parameters.Add("?M2_NVEM", MySqlDbType.Int32).Value = Motherboard.M2_NVEM_Lizdai;
                mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = Motherboard.id_Motinine_Plokste;
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
        public void deleteMotherboard(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM " + "motinine_plokste where id_Motinine_Plokste=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }






    }
}