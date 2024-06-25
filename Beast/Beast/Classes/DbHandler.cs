using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace Beast.Classes
{
    class DbHandler
    {
        //Hier maken we een MySqlConnection met o.a. Server;Database;Uid;Pwd;
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=Beast1;Uid=root;Pwd=;");

        public DataTable GetNumber()
        {
            //Maak een DataTable
            DataTable dt = new DataTable();
            try
            {
                //Open de verbinding
                _connection.Open();
                //Maak een Commando via de connection
                MySqlCommand cmd = _connection.CreateCommand();
                //Zet de CommandText
                cmd.CommandText = "SELECT * FROM `nummer` WHERE 1";
                //Voer de MySqlDataReader uit
                MySqlDataReader dr = cmd.ExecuteReader();
                //Laad het resultaat in de DataTable
                dt.Load(dr);
            }
            catch(Exception e)
            {

            }
            finally
            {
                //Sluit de verbinding
                _connection.Close();
            }


            //Return de DataTable
            return dt;
            
        }

        public int UpdateNumber(string Newcolor, int Newvalue, int ID)
        {
            int amountChanged = 0;
            try
            {
                //Open de verbinding
                _connection.Open();
                //Maak een Commando via de connection
                MySqlCommand AM = _connection.CreateCommand();
                //Zet de CommandText
                AM.CommandText = "UPDATE nummer SET data=@Newvalue, kleur=@Newcolor WHERE ID=@ID";
                AM.Parameters.AddWithValue("@Newvalue", Newvalue);
                AM.Parameters.AddWithValue("@Newcolor", Newcolor);
                AM.Parameters.AddWithValue("@ID", ID);
                //ExecuteNonQuery en zet het resultaat in de int
                amountChanged = AM.ExecuteNonQuery();
   
            }
            catch(Exception e)
            {

            }
            finally
            {
                //Sluit de verbinding
                _connection.Close();
            }

            return amountChanged;
        }

        public void AddNew(string NewKleur, int NewValue)
        {
            bool succes = false;

            try
            {
                _connection.Open();
                MySqlCommand mySqlCommand = _connection.CreateCommand();
                mySqlCommand.CommandText = "INSERT INTO `nummer`(`data`, `kleur`) VALUES (@NewValue, @NewKleur);";
                mySqlCommand.Parameters.AddWithValue("@NewValue", NewValue);
                mySqlCommand.Parameters.AddWithValue("@NewKleur", NewKleur);
                mySqlCommand.ExecuteNonQuery();
                succes = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Someting wong");
            }
            finally 
            {     
                _connection.Close(); 
            }
        }

        public void Delete(int ID) 
        {
            try
            {
                _connection.Open();
                MySqlCommand MySqlCommand = _connection.CreateCommand();
                MySqlCommand.CommandText = "DELETE FROM `nummer` WHERE ID = @ID";
                MySqlCommand.Parameters.AddWithValue("@ID", ID);
                MySqlCommand.ExecuteNonQuery();
            }
            catch 
            {
                MessageBox.Show("someting wong");
            }
            finally 
            {
                _connection.Close();
            }
        }

        public Brush brush(string selColor)
        {
            Brush newBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selColor));
            return newBackground;
        } 
    }
}
