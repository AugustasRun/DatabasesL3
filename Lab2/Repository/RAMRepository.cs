using Lab2.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Repository
{
    public class RAMRepository
    {
        public List<RAMViewModel> getRAMs() {

            List<RAMViewModel> RAMViewModels = new List<RAMViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.Pavadinimas, m.Talpa,m.Atminties_Tipas ,m.Ram_greitis,
                                m.Dydis,m.Papildomi_atributai,m.id_RAM, mm.pavadinimas AS motinine_plokste
                                FROM ram m LEFT JOIN motinine_plokste mm ON 
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
                if (!Convert.IsDBNull(item["Papildomi_atributai"]))
                {
                    temp = Convert.ToString(item["Papildomi_atributai"]);
                }
                else
                {
                    temp = string.Empty;
                }
                
                RAMViewModels.Add(new RAMViewModel
                {
                    Pavadinimas = Convert.ToString(item["Pavadinimas"]),
                    Talpa = Convert.ToString(item["Talpa"]),
                    Atmities_Tipas = Convert.ToString(item["Atminties_Tipas"]),
                    Ram_Greitis = Convert.ToString(item["Ram_greitis"]),
                    Dydis = Convert.ToString(item["Dydis"]),
                    Papildomi_Atributai = temp,
                    id_RAM = Convert.ToInt32(item["id_RAM"]),
                    Motherboard_connection = Convert.ToString(item["motinine_plokste"]),

    
                });
            }

            return RAMViewModels;

        }

        public RAMEditViewModel getRAM(int? id)
        {

            RAMEditViewModel RAMViewModel = new RAMEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* FROM ram m WHERE m.id_RAM=" +id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);

       
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                
                RAMViewModel.Pavadinimas = Convert.ToString(item["Pavadinimas"]);
                RAMViewModel.Talpa = Convert.ToString(item["Talpa"]);
                RAMViewModel.Atmities_Tipas = Convert.ToString(item["Atminties_Tipas"]);
                RAMViewModel.Ram_Greitis = Convert.ToString(item["Ram_greitis"]);
                RAMViewModel.Dydis = Convert.ToString(item["Dydis"]);
                RAMViewModel.Papildomi_Atributai = Convert.ToString(item["Papildomi_atributai"]); ;
                RAMViewModel.id_RAM = Convert.ToInt32(item["id_RAM"]);
                RAMViewModel.Motherboard_connection = Convert.ToInt32(item["fk_Motinine_Ploksteid_Motinine_Plokste"]);
         
            }

            return RAMViewModel;

        }

        public bool updateRAM(RAMEditViewModel RAM)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE ram a SET a.Pavadinimas=?Pavadinimas, a.Talpa=?Talpa,
                    a.Atminties_Tipas=?Atminties_Tipas, a.Ram_greitis=?Ram_greitis,
                    a.Dydis=?Dydis, a.Papildomi_atributai=?Papildomi_atributai, 
                    a.fk_Motinine_Ploksteid_Motinine_Plokste=?motinine_plokste WHERE a.id_RAM=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?Pavadinimas", MySqlDbType.VarChar).Value = RAM.Pavadinimas;
            mySqlCommand.Parameters.Add("?Talpa", MySqlDbType.VarChar).Value = RAM.Talpa;
            mySqlCommand.Parameters.Add("?Atminties_Tipas", MySqlDbType.VarChar).Value = RAM.Atmities_Tipas;
            mySqlCommand.Parameters.Add("?Ram_greitis", MySqlDbType.VarChar).Value = RAM.Ram_Greitis;
            mySqlCommand.Parameters.Add("?Dydis", MySqlDbType.VarChar).Value = RAM.Dydis;
            mySqlCommand.Parameters.Add("?Papildomi_atributai", MySqlDbType.VarChar).Value = RAM.Papildomi_Atributai;
            mySqlCommand.Parameters.Add("?motinine_plokste", MySqlDbType.VarChar).Value = RAM.Motherboard_connection;
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = RAM.id_RAM;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool addRAM(RAMEditViewModel RAM)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO ram(Pavadinimas, Talpa, 
                            Atminties_Tipas, Ram_greitis, Dydis, 
                            Papildomi_atributai, id_RAM,
                            fk_Motinine_Ploksteid_Motinine_Plokste) 
                            VALUES (?Pavadinimas, ?Talpa, 
                            ?Atminties_Tipas, ?Ram_greitis, ?Dydis, 
                            ?Papildomi_atributai, ?id_RAM,
                            ?fk_Motinine_Ploksteid_Motinine_Plokste)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?Pavadinimas", MySqlDbType.VarChar).Value = RAM.Pavadinimas;
            mySqlCommand.Parameters.Add("?Talpa", MySqlDbType.VarChar).Value = RAM.Talpa;
            mySqlCommand.Parameters.Add("?Atminties_Tipas", MySqlDbType.VarChar).Value = RAM.Atmities_Tipas;
            mySqlCommand.Parameters.Add("?Ram_greitis", MySqlDbType.VarChar).Value = RAM.Ram_Greitis;
            mySqlCommand.Parameters.Add("?Dydis", MySqlDbType.VarChar).Value = RAM.Dydis;
            mySqlCommand.Parameters.Add("?Papildomi_atributai", MySqlDbType.VarChar).Value = RAM.Papildomi_Atributai;
            mySqlCommand.Parameters.Add("?fk_Motinine_Ploksteid_Motinine_Plokste", MySqlDbType.VarChar).Value = RAM.Motherboard_connection;
            mySqlCommand.Parameters.Add("?id_RAM", MySqlDbType.VarChar).Value = RAM.id_RAM;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public void deleteRAM(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM ram where id_RAM=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }






    }
}