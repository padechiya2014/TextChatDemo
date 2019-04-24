using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TextChatDemo.Models
{
    public class RTCIRepository
    {

        // To get all the users for the Login
        public bool GetAllUserLogin(string firstName, string Lastname)
        {

            //connection();
            //List<UserLogin> UserLoginList = new List<UserLogin>();

            SqlCommand com = new SqlCommand("GetUsers_Temp", RepositoryConnection.Instance)
            {
                CommandType = CommandType.StoredProcedure
            };

            com.Parameters.AddWithValue("@email", firstName);
            com.Parameters.AddWithValue("@password", Lastname);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            RepositoryConnection.Instance.Open();
            int usercount = (Int32)com.ExecuteScalar();// for taking single value
            //da.Fill(dt);
            RepositoryConnection.Instance.Close();


            if (usercount > 0)
            {
                return true;
            }
            return false;
        }

        //public List<UserModel> GetFriend(int userId)
        //{

        //    List<UserModel> UserFriends = new List<UserModel>();
        //    try
        //    {
               
        //        SqlCommand com = new SqlCommand("GetFriends", RepositoryConnection.Instance)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };

        //        com.Parameters.AddWithValue("@userid", userId);


        //        SqlDataAdapter da = new SqlDataAdapter(com);
        //        DataTable dt = new DataTable();

        //        RepositoryConnection.Instance.Open();
        //        da.Fill(dt);
        //        RepositoryConnection.Instance.Close();


        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            UserFriends.Add(

        //                new UserModel
        //                {

        //                    userid = Convert.ToInt32(dr["userid"]),
        //                    email = Convert.ToString(dr["email"])
        //                }


        //                );
        //        }

              
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //    //connection();
        //    return UserFriends;
        //}

         public List<UserModel> GetAdvisors(int userId)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            List<UserModel> userlist = new List<UserModel>();
            try
            {
               
                SqlCommand com = new SqlCommand("GetFriends", RepositoryConnection.Instance)
                {
                    CommandType = CommandType.StoredProcedure
                };

                com.Parameters.AddWithValue("@userid", userId);


                SqlDataAdapter da = new SqlDataAdapter(com);
               

                RepositoryConnection.Instance.Open();
                da.Fill(ds);
                dt = ds.Tables[0];
                RepositoryConnection.Instance.Close();


                foreach (DataRow row in dt.Rows)
                {
                    UserModel user = new UserModel();
                    user.userid = Convert.ToInt32(row["userid"].ToString());
                    user.email = row["email"].ToString();
                    user.mobile = row["mobile"].ToString();
                    user.password = row["password"].ToString();
                    user.dob = row["dob"].ToString();
                    userlist.Add(user);
                }
                


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            //connection();
            return userlist;
        }
    }
}