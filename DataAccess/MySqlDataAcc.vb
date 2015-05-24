Imports Microsoft.Practices.EnterpriseLibrary
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common

Public Class MySqlDataAcc
    Public Shared Function GetTravelData() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase("ExampleDatabase")
        Using dbCommand As DbCommand = db.GetStoredProcCommand("stp_get_travel_limits")
            Dim resultDs As DataSet = db.ExecuteDataSet(dbCommand)
            Return resultDs.Tables(0)
        End Using
    End Function
End Class
