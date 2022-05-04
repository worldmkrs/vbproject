Imports Product.DataManager
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web
Imports System.Web.Mvc
Imports WebApplication2.Product.DataManager

Namespace Product.Controllers
    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Public Function Index(ByVal BrandID As String, ByVal RegionID As String) As ActionResult
            Try
                Dim results = HomeDataManager.GetHomeList(BrandID, RegionID)
                Dim sb As StringBuilder = New StringBuilder()

                For Each item In results
                    sb.Append(item.Order_id & " " + item.Order_cost & "" + item.Product & "" + item.Qty & "" + item.Brand_ID & "" + item.Region_ID)
                    sb.Append(vbCrLf)
                Next

                Return File(Encoding.ASCII.GetBytes(sb.ToString()), "Order_Details.XML")
            Catch e As Exception
                Dim [error] As String = e.Message
                Throw
            End Try
        End Function
    End Class
End Namespace
