Imports System.IO

Module Module1

    Sub Main()

        Dim filename As String
        Dim data() As Byte
        Dim address As Integer = 0
        Dim lineCount As Integer = -1
        Dim byteCount As Integer = 0

        Console.Write("Enter filename: ")
        filename = Console.ReadLine

        If File.Exists(filename) Then
            Using reader As BinaryReader = New BinaryReader(File.Open(filename, FileMode.Open, FileAccess.Read))
                Do
                    data = reader.ReadBytes(16)
                    byteCount = data.Length
                    If byteCount > 0 Then
                        ' show the address
                        Console.Write(Hex(address).PadLeft(4, "0") & " ")
                        ' display each byte in two hex characters
                        For N = 0 To byteCount - 1
                            Console.Write(Hex(data(N)).PadLeft(2, "0") & " ")
                        Next
                        ' display each byte as an ASCII character
                        ' or a dot if it is not printable
                        For N = 0 To byteCount - 1
                            If data(N) > 31 And data(N) < 127 Then
                                Console.Write(Chr(data(N)))
                            Else
                                Console.Write(".")
                            End If
                        Next
                    End If
                    address += 16
                    Console.WriteLine()
                    lineCount = (lineCount + 1) Mod 16
                    If lineCount = 15 Then
                        Dim k As ConsoleKeyInfo = Console.ReadKey(True) 'read for a key press
                    End If
                Loop While byteCount > 0
                Console.WriteLine()
                Console.WriteLine("End of file")

            End Using

        Else
            Console.WriteLine("File does not exist!")
        End If

        Console.ReadLine()




    End Sub

End Module
