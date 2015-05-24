Imports DataAccess
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page


    Private Const ASCENDING As String = " ASC"
    Private Const DESCENDING As String = " DESC"
    Private isOnSortFired As Boolean = False
    Public Property GridViewSortDirection() As SortDirection
        Get
            If ViewState("sortDirection") Is Nothing Then
                ViewState("sortDirection") = SortDirection.Ascending
            End If

            Return DirectCast(ViewState("sortDirection"), SortDirection)
        End Get
        Set(value As SortDirection)
            ViewState("sortDirection") = value
        End Set
    End Property

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GetDataTable()
        End If
    End Sub


    Protected Sub grdCause_Sorting(sender As Object, e As GridViewSortEventArgs)
        isOnSortFired = True
        Dim sortExpression As String = e.SortExpression
        gvTravelCity.Attributes("CurrentSortField") = sortExpression
        If GridViewSortDirection = SortDirection.Ascending Then
            GridViewSortDirection = SortDirection.Descending
            gvTravelCity.Attributes("CurrentSortDirection") = DESCENDING
            SortGridView(sortExpression, DESCENDING)
        Else
            GridViewSortDirection = SortDirection.Ascending
            gvTravelCity.Attributes("CurrentSortDirection") = ASCENDING
            SortGridView(sortExpression, ASCENDING)
        End If
    End Sub

    Protected Sub grdTravel_RowCreated(sender As Object, e As GridViewRowEventArgs)
        If isOnSortFired AndAlso gvTravelCity.Attributes("CurrentSortField") IsNot Nothing AndAlso gvTravelCity.Attributes("CurrentSortDirection") IsNot Nothing Then
            If e.Row.RowType = DataControlRowType.Header Then
                For Each tableCell As TableCell In e.Row.Cells
                    If tableCell.HasControls() Then
                        Dim sortLinkButton As LinkButton = Nothing
                        If TypeOf tableCell.Controls(0) Is LinkButton Then
                            sortLinkButton = DirectCast(tableCell.Controls(0), LinkButton)
                        End If

                        If sortLinkButton IsNot Nothing AndAlso gvTravelCity.Attributes("CurrentSortField") = sortLinkButton.CommandArgument Then
                            Dim image As New Image()
                            If gvTravelCity.Attributes("CurrentSortDirection") = ASCENDING Then
                                image.ImageUrl = "~/Images/up_arrow.png"
                            Else
                                image.ImageUrl = "~/Images/down_arrow.png"
                            End If
                            tableCell.Controls.Add(New LiteralControl("&nbsp;"))
                            tableCell.Controls.Add(image)
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub SortGridView(sortExpression As String, direction As String)
        Dim dt As DataTable = DirectCast(Session("data_table"), DataTable)
        'Dim dv As New DataView(dt)
        dt.DefaultView.Sort = sortExpression & direction
        BindDataToGrid(dt.DefaultView.ToTable)
    End Sub

    Private Sub GetDataTable()
        Dim dt As DataTable = MySqlDataAcc.GetTravelData()
        BindDataToGrid(dt)
    End Sub

    Private Sub BindDataToGrid(ByRef dt As DataTable)
        Session.Add("data_table", dt)
        gvTravelCity.DataSource = dt
        gvTravelCity.DataBind()
        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, GetType(UpdatePanel), UpdatePanel1.ClientID, "$(function () {$('#gvTravelCity th').each(function (index) {if (index == 0){$('a', this).removeAttr('href');}else if(index >2){$('a', this).removeAttr('href');}});});", True)
    End Sub

    Protected Sub btn1_Click(sender As Object, e As EventArgs)
        GetDataTable()
        lblMsg.Text = "updated"
    End Sub
End Class
