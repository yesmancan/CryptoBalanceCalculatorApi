DB Add New Entity

Add Entity to Domain
 - Goto Package Manager Console
 - Choice Project CryptoApp.Data from Dropdown list
 - Type : Add-Migration "X" : X is your custome name, be carefule selected name is following project standards
   Add-Migration Entity_Add_EntityStatus_Feature -Context CryptoApp.Data.ApplicationDbContext
 - Press Enter
 - Type : Update-Database
      Update-Database -Context CryptoApp.Data.ApplicationDbContext
