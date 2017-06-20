@no echo
md .\data
start mongod --dbpath .\data
mongo localhost:27017 setup.js


