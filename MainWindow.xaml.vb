Imports System.Data
Imports System.Data.SQLite

Class MainWindow
    Dim singleroom As Double = 45.5
    Dim doubleroom As Double = 75.9
    Dim familyroom As Double = 125.5
    Dim onemeal As Double = 7.99
    Dim twomeal As Double = 12.2
    Dim threemeal As Double = 19.5
    Const itax As Double = 0.24
    Dim total, tax As Double

    Private Sub btnexit_Click(sender As Object, e As RoutedEventArgs) Handles btnexit.Click
        Close()
    End Sub

    Private Sub btnreset_Click(sender As Object, e As RoutedEventArgs) Handles btnreset.Click
        txtcid.Text = ""
        txtfname.Text = ""
        txtsname.Text = ""
        txtaddress.Text = ""
        txtpcode.Text = ""
        txtmobile.Text = ""
        txtemail.Text = ""
        combogender.Text = ""
        date1.Text = ""
        date2.Text = ""
        date3.Text = ""
        combonationality.Text = ""
        comboproof.Text = ""
        combomeal.Text = ""
        combortype.Text = ""
        comborno.Text = ""
        combornno.Text = ""
        txtnodays.Text = ""
        txttax.Text = ""
        txtsubtotal.Text = ""
        txttotal.Text = ""
    End Sub

    Private Sub updateTable()
        Dim conn As New SQLiteConnection("Data source=C:\Users\PoojaThammegowda\Downloads\PROJECTS\WEEKLY REPORTS\JAN_MONTH_REPORT\1-9\6th jan\hoteldb.db")
        conn.Open()
        Dim sqlcmd As New SQLiteCommand
        sqlcmd.Connection = conn
        sqlcmd.CommandText = "SELECT * FROM hotel"
        Dim sqlread As SQLiteDataReader = sqlcmd.ExecuteReader
        Dim sqlDT As New DataTable
        sqlDT.Load(sqlread)
        sqlread.Close()
        conn.Close()
        datagrid1.ItemsSource = sqlDT.DefaultView


    End Sub

    Private Sub btntotal_Click(sender As Object, e As RoutedEventArgs) Handles btntotal.Click
        Dim conn As New SQLiteConnection("Data source=C:\Users\PoojaThammegowda\Downloads\PROJECTS\WEEKLY REPORTS\JAN_MONTH_REPORT\1-9\6th jan\hoteldb.db")
        conn.Open()
        Dim sqlcmd As New SQLiteCommand
        sqlcmd.Connection = conn
        sqlcmd.CommandText = "insert into hotel(custref,FirstName,SurName,Address,PostalCode,Mobile,Email,Gender,DOB,Nationality,prove,Datein,Dateout,Meal,Roomtype,Roomno,RoomExt,Totalday,Tax,Subtotal,Total)VALUES (@Rec1,@Rec2,@Rec3,@Rec4,@Rec5,@Rec6,@Rec7,@Rec8,@Rec9,@Rec10,@Rec11,@Rec12,@Rec13,@Rec14,@Rec15,@Rec16,@Rec17,@Rec18,@Rec19,@Rec20,@Rec21)"
        sqlcmd.Parameters.AddWithValue("@Rec1", txtcid.Text)
        sqlcmd.Parameters.AddWithValue("@Rec2", txtfname.Text)
        sqlcmd.Parameters.AddWithValue("@Rec3", txtsname.Text)
        sqlcmd.Parameters.AddWithValue("@Rec4", txtaddress.Text)
        sqlcmd.Parameters.AddWithValue("@Rec5", txtpcode.Text)
        sqlcmd.Parameters.AddWithValue("@Rec6", txtmobile.Text)
        sqlcmd.Parameters.AddWithValue("@Rec7", txtemail.Text)
        sqlcmd.Parameters.AddWithValue("@Rec8", combogender.Text)
        sqlcmd.Parameters.AddWithValue("@Rec9", date1.Text)
        sqlcmd.Parameters.AddWithValue("@Rec10", combonationality.Text)
        sqlcmd.Parameters.AddWithValue("@Rec11", comboproof.Text)
        sqlcmd.Parameters.AddWithValue("@Rec12", date2.Text)
        sqlcmd.Parameters.AddWithValue("@Rec13", date2.Text)
        sqlcmd.Parameters.AddWithValue("@Rec14", combomeal.Text)
        sqlcmd.Parameters.AddWithValue("@Rec15", combortype.Text)
        sqlcmd.Parameters.AddWithValue("@Rec16", comborno.Text)
        sqlcmd.Parameters.AddWithValue("@Rec17", combornno.Text)
        sqlcmd.Parameters.AddWithValue("@Rec18", txtnodays.Text)
        sqlcmd.Parameters.AddWithValue("@Rec19", txttax.Text)
        sqlcmd.Parameters.AddWithValue("@Rec20", txtsubtotal.Text)
        sqlcmd.Parameters.AddWithValue("@Rec21", txttotal.Text)

        sqlcmd.ExecuteNonQuery()
        conn.Close()
        updateTable()

    End Sub

    Private Sub btndelete_Click(sender As Object, e As RoutedEventArgs) Handles btndelete.Click
        Dim recid As Integer = datagrid1.SelectedItem(0)
        Dim conn As New SQLiteConnection("Data source=C:\Users\PoojaThammegowda\Downloads\PROJECTS\WEEKLY REPORTS\JAN_MONTH_REPORT\1-9\6th jan\hoteldb.db")
        conn.Open()
        Dim sqlcmd As New SQLiteCommand
        sqlcmd.Connection = conn
        sqlcmd.CommandText = "delete from hotel where ID=@ID"
        sqlcmd.Parameters.AddWithValue("@ID", recid)
        sqlcmd.ExecuteNonQuery()
        conn.Close()
        updateTable()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As RoutedEventArgs) Handles btnupdate.Click
        Dim recid As Integer = datagrid1.SelectedItem(0)
        Dim conn As New SQLiteConnection("Data source=C:\Users\PoojaThammegowda\Downloads\PROJECTS\WEEKLY REPORTS\JAN_MONTH_REPORT\1-9\6th jan\hoteldb.db")
        conn.Open()
        Dim sqlcmd As New SQLiteCommand
        sqlcmd.Connection = conn
        sqlcmd.CommandText = "update hotel set ID=@ID,custref=@custref,FirstName=@FirstName,SurName=@SurName,Address=@Address,PostalCode=@PostalCode,Mobile=@Mobile,Email=@Email,Gender=@Gender,DOB=@DOB,Nationality=@Nationality,
prove=@prove,Datein=@Datein,Dateout=@Dateout,Meal=@Meal,Roomtype=@Roomtype,Roomno=@Roomno,RoomExt=@RoomExt,Totalday=@Totalday,
Tax=@Tax,Subtotal=@Subtotal,Total=@Total where ID=@ID"
        sqlcmd.Parameters.AddWithValue("@custref", txtcid.Text)
        sqlcmd.Parameters.AddWithValue("@FirstName", txtfname.Text)
        sqlcmd.Parameters.AddWithValue("@SurName", txtsname.Text)
        sqlcmd.Parameters.AddWithValue("@Address", txtaddress.Text)
        sqlcmd.Parameters.AddWithValue("@PostalCode", txtpcode.Text)
        sqlcmd.Parameters.AddWithValue("@Mobile", txtmobile.Text)
        sqlcmd.Parameters.AddWithValue("@Email", txtemail.Text)
        sqlcmd.Parameters.AddWithValue("@Gender", combogender.Text)
        sqlcmd.Parameters.AddWithValue("@DOB", date1.Text)
        sqlcmd.Parameters.AddWithValue("@Nationality", combonationality.Text)
        sqlcmd.Parameters.AddWithValue("@prove", comboproof.Text)
        sqlcmd.Parameters.AddWithValue("@Datein", date2.Text)
        sqlcmd.Parameters.AddWithValue("@Dateout", date2.Text)
        sqlcmd.Parameters.AddWithValue("@Meal", combomeal.Text)
        sqlcmd.Parameters.AddWithValue("@Roomtype", combortype.Text)
        sqlcmd.Parameters.AddWithValue("@Roomno", comborno.Text)
        sqlcmd.Parameters.AddWithValue("@RoomExt", combornno.Text)
        sqlcmd.Parameters.AddWithValue("@Totalday", txtnodays.Text)
        sqlcmd.Parameters.AddWithValue("@Tax", txttax.Text)
        sqlcmd.Parameters.AddWithValue("@Subtotal", txtsubtotal.Text)
        sqlcmd.Parameters.AddWithValue("@Total", txttotal.Text)
        sqlcmd.Parameters.AddWithValue("@ID", recid)
        sqlcmd.ExecuteNonQuery()
        conn.Close()
        updateTable()
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        updateTable()
    End Sub
    Private Sub noofdays()
        Dim f As DateTime = Convert.ToDateTime(date1.Text)
        Dim s As DateTime = Convert.ToDateTime(date2.Text)

        Dim de As TimeSpan = s.Subtract(s)
        Dim TD = Convert.ToInt64(de.Days)
        txtnodays.Text = Convert.ToString(TD)

    End Sub


End Class
