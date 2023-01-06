# Play the original game!
## [Treacherous Trials](https://gdcolon.com/tt)


# Opening the project
1) Download the project files.
```git clone git@github.com:FoxSylv1/treacherous-trials-plus.git``` (You need to have git)

2) Make sure to have Unity 2021 so everything works correctly

3) Use `Unity Hub` to open the cloned directory (the name of the project
you're trying to open should read `treacherous-trials-plus`).

4) The project should open after some loading time, and be
fully functional.


# Making your own custom mods!
## Tiles
Included in the source code is the full tileset for use in
Unity's 2D Tile Palette (see `Assets/Tiles`). This can be used to
make any custom level you so desire. Note that the Z-index option in
the tile palette can allow for tiles to overlap on the same tilemap.

A note on the tiles: the three copies of each sprite correspond to
how that in-object behaves upon switching. The top one (red/yellow) is
always active, the middle one (also red/yellow) switches, and is on by default,
and the bottom one (blue/green) switched, and is off by default.

## Note on Scripts
Since the scripts had to be decompiled from the original game, there may be
some parts of scripts that seem bizarre upon first look-through. In addition,
some scripts had to be modified so that the original game's behaviour was
properly reflected. Other than this, the scripts should be relatively readable.

# Happy creating ^w^
