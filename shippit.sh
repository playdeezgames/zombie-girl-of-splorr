rm -rf ./pub-html
dotnet publish ./src/Contemn/Contemn.csproj -o ./pub-html -c Release 
rm -f ./pub-html/*.pdb
butler push pub-html/wwwroot thegrumpygamedev/tggd-zgos:html
