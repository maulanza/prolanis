Public Class DataSources
    Public Shared Property gammuDataSet() As gammuDataSet
        Get
            Return m_gammuDataSet
        End Get
        Set(value As gammuDataSet)
            m_gammuDataSet = value
        End Set
    End Property
    Private Shared m_gammuDataSet As gammuDataSet
End Class
