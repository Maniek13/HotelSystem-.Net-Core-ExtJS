# HotelSystem

Backend
1. Create new ASP.NET Core (Model-View-Controller) .Net5.0 named HotelSys
2. Delete folders Views, Controllers, Models
3. Copy files from repo/backend/hotelsys to your app directory
4. Instal EntityFreamwork, run this command  from NuGet console: Install-Package EntityFramework
5. In NuGet console, run command: update-database
6. Run Program

Fronted
1. Create new ExtJS app. In bash run: ext-gen app -a -t moderndesktopminimal -n HotelSys
2. Delete folder app/desktop/src/view/main
3. Copy files from repo
4. In bash run: npm start

If don't show table, mayby must change proxy in url in app/desktop/src/view/reservation/ReservationVieModel.js to yours. It's show in server adres when you start it.
