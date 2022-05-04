Imports System
Imports System.Collections.Generic
Imports Oracle.ManagedDataAccess.Client
Imports Product.Models
Imports System.Data
Imports System.Configuration
Imports System.Data.OracleClient
Imports WebApplication2.Product.Models

Namespace Product.DataManager
    Public Class HomeDataManager
        Inherits BaseClass

        Public Shared Function GetHomeList(ByVal BrandID As String, ByVal RegionID As String) As List(Of HomeModel)
            Dim con As OracleConnection = New OracleConnection(ConfigurationManager.ConnectionStrings("connString").ConnectionString)
            Dim listItems As List(Of HomeModel) = New List(Of HomeModel)()
            Dim requestDetail As HomeModel
            Dim cmd As OracleCommand = New OracleCommand(PKG_ORDER_RESULTS, con)
            cmd.CommandType = CommandType.StoredProcedure

            Try

                Using con

                    Using cmd
                        con.Open()
                        cmd.Parameters.Add("BrandID", OracleType.NVarChar).Value = BrandID
                        cmd.Parameters.Add("RegionID", OracleType.NVarChar).Value = RegionID
                        cmd.Parameters.Add("Error_no", OracleType.Int32).Value = ParameterDirection.Output
                        cmd.Parameters.Add("Error_desc", OracleType.NVarChar, 4000).Value = ParameterDirection.Output
                        cmd.Parameters.Add("RegionID", OracleType.Cursor).Direction = ParameterDirection.Output

                        Using dr As OracleDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            Dim dt As DataTable = New DataTable()
                            dt.Load(dr)

                            For Each row As DataRow In dt.Rows
                                requestDetail = New HomeModel()
                                requestDetail.Order_id = If(row("Order_id") <> DBNull.Value, Convert.ToString(row("Order_id")), String.Empty)
                                requestDetail.Order_cost = If(row("Order_cost") <> DBNull.Value, Convert.ToString(row("Order_cost")), String.Empty)
                                requestDetail.Product = If(row("Product") <> DBNull.Value, Convert.ToString(row("Product")), String.Empty)
                                requestDetail.Qty = If(row("Qty") <> DBNull.Value, Convert.ToString(row("Qty")), String.Empty)
                                requestDetail.Brand_ID = If(row("Brand_ID") <> DBNull.Value, Convert.ToString(row("Brand_ID")), String.Empty)
                                requestDetail.Region_ID = If(row("Region_ID") <> DBNull.Value, Convert.ToString(row("Region_ID")), String.Empty)
                                listItems.Add(requestDetail)
                            Next

                            Return listItems
                        End Using
                    End Using
                End Using

            Catch e As Exception
                Dim [error] As String = e.Message
                Throw
            End Try
        End Function
    End Class
End Namespace
