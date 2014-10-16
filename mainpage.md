# Musicista #

%Musicista is a tool that combines music with computer science and offers the ability to run algorithms on musical notation. It has its own file format `.musicista` to store all information, but it can also read `MusicXML`- and `%Midi`-files.

The official website is [www.musicistaapp.de](http://www.musicistaapp.de), you can find the documentation at [www.musicistaapp.de/doc/](http://www.musicistaapp.de/doc/).

####Packages####
The main packages are

- Musicista: the main project
  - UI: the view-model classes
  - View: windows etc.
  - Sidebar: the information, view and algorithm sidebar
  - Mappers: map between MusicXML, Midi and Musicista
- Model: the logical data structure and API

also important are

- Algorithms: a beginning of the algorithms that can later be added
- Collection: data structure files for the collection view
- MuseScoreAPI: data structure for REST response from the musescore.org server
- Midi: data structure for Midi files as well as a parser

Note that the MusicXML package is *not* described in this documentation, since it is too huge.


(c) 2014 by Jannik Arndt