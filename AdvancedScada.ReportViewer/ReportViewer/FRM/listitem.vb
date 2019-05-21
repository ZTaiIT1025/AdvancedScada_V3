
Public Class listitem
    Private _text As String = String.Empty
    Private _value As Integer

    Public Sub New(ByVal text As String, ByVal value As Integer)
        _text = text
        _value = value
    End Sub

    Public Property text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property
    Public Property value() As Integer
        Get
            Return _value
        End Get
        Set(ByVal value As Integer)
            _value = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return _text
    End Function
End Class