﻿namespace EmuLoader.Core.Classes
{
    public enum Region
    {
        USA,
        JPN,
        EUR,
        WLD,
        MSC,
        UNK
    }

    public enum Column
    {
        ColumnPath,
        PlatformsList,
        ColumnRating,
        ColumnYearReleased,
        ColumnPublisher,
        ColumnDeveloper,
        ColumnGenre,
        ColumnStatus,
        ColumnLabels,
        ColumnPlatform,
        ColumnFileName,
        ColumnRomDBName,
        ColumnRomSeries,
        BoxArt,
        TitleArt,
        GameplayArt
    }

    public enum Folder
    {
        Retroarch,
        MAME
    }


    public enum PicType
    {
        BoxArt,
        Title,
        Gameplay
    }
}
