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
    public class PowerBrickRepository
    {
        public List<PowerBrickViewModel> getBricks()
        {

            List<PowerBrickViewModel> powerBrickViewModels = new List<PowerBrickViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.Pavadinimas, m.Maksimali_galia,
            m.Energijos_effektybumo_reitingas  ,m.Ausintuvo_dydis,m.Jungikliai,
            m.id_Maitinimo_blokas, mm.pavadinimas AS motinine_plokste FROM 
            maitinimo_blokas m LEFT JOIN motinine_plokste mm ON 
            m.fk_Motinine_Ploksteid_Motinine_Plokste=mm.id_Motinine_Plokste";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {

                powerBrickViewModels.Add(new PowerBrickViewModel
                {
                    Pavadinimas = Convert.ToString(item["Pavadinimas"]),
                    Power = Convert.ToString(item["Maksimali_galia"]),
                    Efficiency = Convert.ToString(item["Energijos_effektybumo_reitingas"]),
                    Fan_size = Convert.ToString(item["Ausintuvo_dydis"]),
                    Swithces = Convert.ToString(item["Jungikliai"]),
                    id_Brick = Convert.ToInt32(item["id_Maitinimo_blokas"]),
                    Motherboard = Convert.ToString(item["motinine_plokste"]),


                });
            }
            return powerBrickViewModels;
        }

        public PowerBrickEditViewModel getBrick(int id)
        {

            PowerBrickEditViewModel powerBrickViewModel = new PowerBrickEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* FROM maitinimo_blokas m WHERE m.id_Maitinimo_blokas=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);


            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {

                powerBrickViewModel.Pavadinimas = Convert.ToString(item["Pavadinimas"]);
                powerBrickViewModel.Power = Convert.ToString(item["Maksimali_galia"]);
                powerBrickViewModel.Efficiency = Convert.ToString(item["Energijos_effektybumo_reitingas"]);
                powerBrickViewModel.Fan_size = Convert.ToString(item["Ausintuvo_dydis"]);
                powerBrickViewModel.Swithces = Convert.ToString(item["Jungikliai"]);
                powerBrickViewModel.id_Power = Convert.ToInt32(item["id_Maitinimo_blokas"]); ;
                powerBrickViewModel.Motherboard = Convert.ToInt32(item["fk_Motinine_Ploksteid_Motinine_Plokste"]);
            }

            return powerBrickViewModel;

        }

        public bool updateBrick(PowerBrickEditViewModel powerBrick)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE maitinimo_blokas a SET a.Pavadinimas=?Pavadinimas, a.Maksimali_galia=?Maksimali_galia,
                    a.Energijos_effektybumo_reitingas=?Energijos_effektybumo_reitingas, a.Ausintuvo_dydis=?Ausintuvo_dydis,
                    a.Jungikliai=?Jungikliai, a.fk_Motinine_Ploksteid_Motinine_Plokste=?motinine_plokste WHERE a.id_Maitinimo_blokas=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?Pavadinimas", MySqlDbType.VarChar).Value = powerBrick.Pavadinimas;
            mySqlCommand.Parameters.Add("?Maksimali_galia", MySqlDbType.VarChar).Value = powerBrick.Power;
            mySqlCommand.Parameters.Add("?Energijos_effektybumo_reitingas", MySqlDbType.VarChar).Value = powerBrick.Efficiency;
            mySqlCommand.Parameters.Add("?Ausintuvo_dydis", MySqlDbType.VarChar).Value = powerBrick.Fan_size;
            mySqlCommand.Parameters.Add("?Jungikliai", MySqlDbType.VarChar).Value = powerBrick.Swithces;
            mySqlCommand.Parameters.Add("?motinine_plokste", MySqlDbType.VarChar).Value = powerBrick.Motherboard;
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = powerBrick.id_Power;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }
        public bool addBrick(PowerBrickEditViewModel powerBrick)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO maitinimo_blokas(Pavadinimas, Maksimali_galia, 
                            Energijos_effektybumo_reitingas, Ausintuvo_dydis, Jungikliai, 
                            id_Maitinimo_blokas,
                            fk_Motinine_Ploksteid_Motinine_Plokste) 
                            VALUES (?Pavadinimas, ?Maksimali_galia, 
                            ?Energijos_effektybumo_reitingas, ?Ausintuvo_dydis, ?Jungikliai, 
                            ?id_Maitinimo_blokas, ?fk_Motinine_Ploksteid_Motinine_Plokste)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?Pavadinimas", MySqlDbType.VarChar).Value = powerBrick.Pavadinimas;
            mySqlCommand.Parameters.Add("?Maksimali_galia", MySqlDbType.VarChar).Value = powerBrick.Power;
            mySqlCommand.Parameters.Add("?Energijos_effektybumo_reitingas", MySqlDbType.VarChar).Value = powerBrick.Efficiency;
            mySqlCommand.Parameters.Add("?Ausintuvo_dydis", MySqlDbType.VarChar).Value = powerBrick.Fan_size;
            mySqlCommand.Parameters.Add("?Jungikliai", MySqlDbType.VarChar).Value = powerBrick.Swithces;
            mySqlCommand.Parameters.Add("?fk_Motinine_Ploksteid_Motinine_Plokste", MySqlDbType.VarChar).Value = powerBrick.Motherboard;
            mySqlCommand.Parameters.Add("?id_Maitinimo_blokas", MySqlDbType.VarChar).Value = powerBrick.id_Power;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public void deleteBrick(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM maitinimo_blokas where id_Maitinimo_blokas=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }


    }
}