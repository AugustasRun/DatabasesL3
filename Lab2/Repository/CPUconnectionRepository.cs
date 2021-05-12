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
    public class CPUconnectionRepository
    {
        public List<CPUconnections> getAllCPUConnections(int? from, int? to)
        {
            List<CPUconnections> cpuConnections = new List<CPUconnections>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT motinine_plokste.Pavadinimas as MotPav, id_Motinine_Plokste as MOTserijosNR, COUNT(DISTINCT cpu.id_CPU) as counterCPU, COUNT(aušintuvai.fk_CPUid_CPU) as counterCooler 
                                FROM motinine_plokste
                                LEFT JOIN cpu ON cpu.fk_Motinine_Ploksteid_Motinine_Plokste=motinine_plokste.id_Motinine_Plokste
                                LEFT JOIN aušintuvai ON aušintuvai.fk_CPUid_CPU=cpu.id_CPU
                                WHERE id_Motinine_Plokste>=IFNULL(?from, id_Motinine_Plokste) and id_Motinine_Plokste<=IFNULL(?to, id_Motinine_Plokste)
                                group by motinine_plokste.id_Motinine_Plokste ASC";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?from", MySqlDbType.Int32).Value = from;
            mySqlCommand.Parameters.Add("?to", MySqlDbType.Int32).Value = to;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                cpuConnections.Add(new CPUconnections
                {
                    Name = Convert.ToString(item["MotPav"]),
                    ID = Convert.ToString(item["MOTserijosNR"]),
                    Cpu_Count = Convert.ToInt32(item["counterCPU"]),
                    Cooler_Count = Convert.ToInt32(item["counterCooler"])

                });
            }
            return cpuConnections;
        }
    }
}