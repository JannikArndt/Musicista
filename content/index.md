+++
Title = "Home"
+++

# Musicista #

<center style="float: right">![Musicista](icon.png)</center>

Musicista is a tool that combines music with computer science and offers the ability to run algorithms on musical notation. It has its own file format `.musicista` to store all information, but it can also read `MusicXML`- and `Midi`-files.

<br>

This software is licensed under [GPL v3.0](http://www.gnu.org/licenses/gpl-3.0.txt).

<br><br>

<a class="btn btn-success" href="https://raw.githubusercontent.com/JannikArndt/Musicista/master/setup/Musicista.application">Install Windows-App</a>
<a class="btn btn-primary" href="https://www.github.com/JannikArndt/Musicista">View on Github</a>
<a class="btn btn-info" href="https://www.facebook.com/MusicistaApp">Like on Facebook</a>

<center>![Musicista](screenshot.png)</center>

# File Format

Musicista files have six sections:

``` html
    <Piece>
      <Meta />
      <Instruments />
      <Score />
      <Parts />
      <Comments />
      <Style />
    </Piece>
```

The __meta data__ section stores title, composer, etc.:

``` xml
    <Meta>
      <Title>Gute Nacht</Title>
      <Subtitle>Ein Cyclus von Liedern von Wilhelm Müller. Für eine Singstimme mit Begleitung des   Pianoforte</Subtitle>
      <People>
        <Composer FirstName="Franz" LastName="Schubert" Born="1797-01-31" Died="1828-11-19" />
        <Lyricist FirstName="Wilhelm" LastName="Müller" Born="1794-10-07" Died="1827-10-01" />
      </People>
      <Collection>Die Winterreise</Collection>
      <Opus Number="89" SubNumber="0" />
      <Epoch>Romantik</Epoch>
      <Form>Lied</Form>
      <Dates>
        <Composition Date="1827-02" />
        <Publication Date="1828-01-24" Publisher="Tobias Haslinger" />
        <Performance Date="1828-01-10" IsFirst="true" Place="Musikverein, Wien">Ludwig Tietze</Performance>
        <Engraving Date="2014-09-10" Typesetter="Jannik Arndt" />
      </Dates>
      <Dedication />
      <AverageDuration>5:38</AverageDuration>
      <BeatsPerMinute>90</BeatsPerMinute>
      <MusicalKey Step="D" Gender="Minor" />
      <Copyright>Public Domain</Copyright>
      <Weblink>http://musicistaapp.de/?ddownload=62</Weblink>
      <Notes>Deutsch-Verzeichnis D911</Notes>
      <Software>Musicista 1.0</Software>
    </Meta>
```

The __instruments__ section defines instrument groups, instruments and staves:

``` xml
    <Instruments>
      <InstrumentGroup Name="Woodwind" BraceType="Bracket">
        <Instrument ID="1" Name="Flute 1" Shortname="Fl. 1">
          <Staff ID="1"/>
        </Instrument>
        <Instruments ID="2" Name="Flute 2" Shortname="Fl. 2">
          <Staff ID="2" PrintInStaff="1"/>
        </Instrument>
      </InstrumentGroup>
      <InstrumentGroup Name="Brass" BraceType="None">
        <Instrument ID="3" Name="Trumpet in Bb" Transposition="-2">
          <Staff ID="3"/>
        </Instrument>
      </InstrumentGroup>
      <InstrumentGroup Name="Keys" BraceType="Brace">
        <Instrument ID="4" Name="Piano" Shortname="Pno.">
          <Staff ID="4"/>
          <Staff ID="5"/>
        </Instrument>
      </InstrumentGroup>
      <InstrumentGroup Name="Strings" BraceType="Bracket">
        <Instrument ID="5" Name="Violoncello" Shortname="Vc.">
          <Staff ID="6"/>
        </Instrument>
        <Instrument ID="6" Name="Double Bass" Shortname="Db.">
          <Staff ID="7"/>
        </Instrument>
      </InstrumentGroup>
    </Instruments>
```

The actual music is stored in the __Score__ section, hierarchically structured:

``` xml
    <Score>
      <Section>
        <Movement Number="0" BeatsPerMinute="0">
          <Segment>
            <Passage>
              <MeasureGroup MeasureNumber="1">...</MeasureGroup>
            </Passage>
          </Segment>
        </Movement>
      </Section>
    </Score>
```

__MeasureGroup__ tags group measures from different instruments that occur at the same time in the score. This resembles the <em>timewise</em> dialect of MusicXML.

``` xml
    <MeasureGroup MeasureNumber="6" RehearsalMark="A">
      <TimeSignature Beats="4" BeatUnit="4"/>
      <KeySignature Step="F" Gender="Major"/>
      <Tempo Beat="1" Text="Allegro" />
      <Repetition Beat="4" Sign="SegnoSign" />
      <Barline Location="Right" Type="EndRepeat"/>
      <Measure Clef="Treble" InstrumentID="1" StaffID="1">
        <Note Voice="1" Duration="Quarter" Beat="1" Step="C" Octave="5"/>
        <Note Voice="1" Duration="Quarter" Beat="2" Step="D" Octave="5"/>
        <Note Voice="1" Duration="Quarter" Beat="3" Step="E" Octave="5"/>
        <Note Voice="1" Duration="Quarter" Beat="4" Step="F" Octave="5"/>
      </Measure>
      <Measure Clef="Bass" InstrumentID="2" StaffID="2">
        <Note Voice="1" Duration="Whole" Beat="1" Step="C" Octave="3"/>
      </Measure>
    </MeasureGroup>
```

__Notes__ consist of Step, Octave, Duration and Beat but can have several additional attributes. Possible child tags are Articulation, Lyrics and analysis tags such as Harmony or NoteAttribute:

``` xml
    <Note Step="C" Octave="4" Duration="Eighth" Beat="1" Voice="1">
      <Articulation Bowing="Pizzicato" Accent="Marcato">Griffbrett</Articulation>
      <Lyrics>
        <Lyric Line="1" Syllabic="Single">Eins</Lyric>
        <Lyric Line="2" Syllabic="Single">Zwei</Lyric>
        <Lyric Line="3" Syllabic="Single">Drei</Lyric>
        <Lyric Line="4" Syllabic="Single">Vier</Lyric>
      </Lyrics>
      <Harmony Step="C" Gender="Major" Function="Tonic" />
      <NoteAttribute SetOn="2014-09-17">Free Text</NoteAttribute>
    </Note>
```

Musicista can also store additional information, such as themes, in the __Parts__ section:

``` xml
    <Parts>
      <Part Name="Theme #1" Movement="1">
        <Start MeasureNumber="0" StaffNumber="1" Beat="1.75" />
        <End MeasureNumber="1" StaffNumber="1" Beat="1" />
        <Passage>
          <MeasureGroup MeasureNumber="0">...</MeasureGroup>
          <MeasureGroup MeasureNumber="1">...</MeasureGroup>
        </Passage>
      </Part>
    </Parts>
```

Comments can be stored in the __Comments__ section

``` xml
    <Comments>
      <Comment Name="c1" Movement="1" Author="Jannik">
        <Text>Interesting passage</Text>
        <NoteReference MeasureNumber="0" StaffNumber="1" Beat="1.75" />
      </Comment>
    </Comments>
```

And, although it is not a graphical format, some stylistic information can be stored in the __Style__ tag:

``` xml
    <Style>
      <MovementMetric MovementNumber="1">
        <Margin Left="60" Top="60" Right="60" BelowTitle="50" />
        <Staff Spacing="20" />
        <System Spacing="40" />
        <MeasuresPerSystem Threshold="280" Division="6,6,6,6,6,4,5,3,..." />
      </MovementMetric>
    </Style>
```

# Screenshots

<center>![Musicista](screenshot_start.png)</center>
<center>![Musicista](screenshot_collection.png)</center>
<center>![Musicista](screenshot_musescore.png)</center>
<center>![Musicista](screenshot_score.png)</center>
<center>![Musicista](screenshot_selection.png)</center>

# TinyNotation

TinyNotation is easy and intuitive:

- Start with the note name: __a__, __b__, __c__, __d__, __e__, __f__, __g__ or __r__ for a rest
- Select the octave by repeating the note name or writing upper case: __CCC__ > __CC__ > __C__ > __c__ > __cc__ > __ccc__
- Separate notes with space: __cc dd e f g a r__
- Now write the duration: __cc8__ for example.
- If the duration is the same as before, you don't have to specify it: __cc8 dd e f g4 a r1__
- Dotted notes work as well: __cc8__.
- Add articulation in parenthesis: __cc8.(pp,accent)__
- And lyrics in brackets: __cc8.(pp,accent)[Gloria,Oh]__ (separate lines with comma)
- That's it!

Thanks to the guys at [music21](http://web.mit.edu/music21/) who inspired this dialect!

All articulation keywords:

- p, pp, ppp, pppp, ppppp, pppppp
- f, ff, fff, ffff, fffff, ffffff
- fp, fz, mf, mp
- rf, rfz, sf, sfz, sffz, sfp, sfpp
- marcato, staccato, staccatissimo, accent, tenuto, portato,
- legato
- arpeggiate
- damping
- dolce
- espressivo
- trill
- Slurs: begin = {, middle = _, end = }
- mordent, invmordent (inverted mordent)
- turn, invturn (inverted turn), delturn (delayed turn), delinvturn (delayed inverted turn)
- schleifer, shake, wavyline