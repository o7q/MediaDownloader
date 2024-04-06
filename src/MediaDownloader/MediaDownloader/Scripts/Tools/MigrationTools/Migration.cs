using MediaDownloader.Tools.MigrationTools.Functions;

namespace MediaDownloader.Tools.MigrationTools
{
    public static class Migrator
    {
        public static void Run()
        {
            QueueItemPack.MigrateQueueItemPack("queue");
            QueueItemPack.MigrateQueueItemPack("history");
        }
    }
}