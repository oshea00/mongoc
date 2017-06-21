# Example using MongoDB.Driver #

## Prerequisites ##

* Install mongodb community edition. 
* Add path to mongod.exe executable - example: "C:\Program Files\MongoDB\Server\3.4\bin" to system path.

## Setup database ##

* cd [projectdir]\mongoc
* Run Setup.bat from command window.
* Close command windows.
* Note where the mongod.exe was installed. You'll need this for mongoExePath.
* Note that the Setup.bat creates your db directory at [projectdir]\data
* Edit MainWindow.xaml.cs line 20 to pass the correct mongoExepath adnd dbdirpath strings.

## Run ##



