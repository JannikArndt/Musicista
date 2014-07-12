![Musicista](https://dl.dropboxusercontent.com/u/18607039/AppIconSmall.png)

# Musicista #

Musicista is a tool that combines music with computer science and offers the ability to run algorithms on musical notation. It has its own file format `.musicista` to store all information, but it can also read `MusicXML`- and `Midi`-files.

##Release Notes##

###v0.5 (current)###
- Added symbols for common- and cut-time (TODO)

###v0.4 (12.7.2014)###
- Entirely new engraving, now with seperated head, stem and flag
- Stems are now extended fo beaming
- Support for Parts: Themes and other passages can be saved, displayed and selected in the score
- Time Signatures are displayed
- Example files (Abendstück, Beethoven 1st sonata, cheat sheet for clefs, keys and times)

###v0.3 (23.6.2014)###
- Support for setting measurements such as staff-spacing, system-spacing, …
- Notes and rests derive from canvas as well
- Selection of notes and measures
- Introduced Passages as a model for selected notes

###v0.2 (19.6.2014)###
- New view-structure: almost everything is a canvas
- Updated Model
- “Save as” implemented
- Basic Midi-file-support
- Better MusicXML-support (<backup>-Tag)
- Basic selection of measures and support in the sidebar
- Beaming of notes

###v0.1 (5.5.2014)###
- Mapping from MusicXML to Musicista
- Basic displaying of notes and rests
- GUI