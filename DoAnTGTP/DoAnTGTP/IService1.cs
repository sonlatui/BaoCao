using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DoAnTGTP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IService1
    {
        [OperationContract]
        int Login(string username,string password);
        [OperationContract]
        User GetQuyen();
        
        [OperationContract]
        string GetTSTGbyTG(string tacgia);
        [OperationContract]
        string GetTSTGbyND(string tacgia);
        [OperationContract]

        string GetTPbyTG(string tacgia);
        [OperationContract]
        string GetTPbyTP(string tacpham);
        [OperationContract]
        string GetTPbyTL(string tacpham);
        [OperationContract]
        string GetTPbyND(string tacpham);
//
        //[OperationContract]
        //DataSet TimTSbyTen(string tacgia);
        // TODO: Add your service operations here
        [OperationContract]
        string ThemTG(string tentg, string tieusu);
        [OperationContract]
        string ThemTP(string tentp, string theloai, string noidung, string tentg);
        [OperationContract]
        void Logout();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations
    [DataContract]
    public class User
    {
        [DataMember]
        public int Quyen =-1;
        [DataMember]
        public string username = "";
    }
}
