BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "tag" (
	"channelid"	int NOT NULL,
	"deviceid"	int NOT NULL,
	"datablockid"	int NOT NULL,
	"tagid"	int NOT NULL,
	"tagname"	text NOT NULL,
	"tagprefix"	text NOT NULL,
	"address"	double NOT NULL,
	"datatype"	int NOT NULL DEFAULT 0,
	"size"	int NOT NULL,
	"description"	text NOT NULL,
	PRIMARY KEY("tagid","datablockid","deviceid","channelid"),
	FOREIGN KEY("datablockid","deviceid","channelid") REFERENCES "datablock"("datablockid","deviceid","channelid")
);
CREATE TABLE IF NOT EXISTS "service" (
	"serviceid"	int NOT NULL,
	"servicename"	text NOT NULL,
	"type"	int NOT NULL,
	"status"	int NOT NULL,
	"date"	text DEFAULT current_timestamp,
	"message"	text,
	PRIMARY KEY("serviceid")
);
CREATE TABLE IF NOT EXISTS "logging" (
	"date"	text NOT NULL DEFAULT current_timestamp,
	"loggingtype"	int NOT NULL,
	"message"	text,
	PRIMARY KEY("date")
);
CREATE TABLE IF NOT EXISTS "iodefine" (
	"iodefineid"	int NOT NULL,
	"input"	text NOT NULL,
	"output"	text NOT NULL,
	PRIMARY KEY("iodefineid")
);
CREATE TABLE IF NOT EXISTS "ioconfig" (
	"ioconfigid"	int NOT NULL,
	"tagname"	text NOT NULL,
	"isinput"	int NOT NULL DEFAULT 1,
	PRIMARY KEY("ioconfigid","isinput")
);
CREATE TABLE IF NOT EXISTS "datablock" (
	"channelid"	int NOT NULL,
	"deviceid"	int NOT NULL,
	"datablockid"	int NOT NULL,
	"datablockname"	text NOT NULL,
	"memorytype"	int NOT NULL DEFAULT 0,
	"dbnumber"	int NOT NULL DEFAULT 0,
	"description"	text NOT NULL,
	PRIMARY KEY("datablockid","deviceid","channelid"),
	FOREIGN KEY("deviceid","channelid") REFERENCES "device"("deviceid","channelid")
);
CREATE TABLE IF NOT EXISTS "device" (
	"channelid"	int NOT NULL,
	"deviceid"	int NOT NULL,
	"devicename"	text NOT NULL,
	"cputype"	int NOT NULL,
	"ipaddress"	text NOT NULL,
	"rack"	int NOT NULL DEFAULT 0,
	"slot"	int NOT NULL DEFAULT 1,
	"description"	text NOT NULL,
	"isactived"	int DEFAULT 1,
	PRIMARY KEY("deviceid","channelid"),
	FOREIGN KEY("channelid") REFERENCES "channel"("channelid")
);
CREATE TABLE IF NOT EXISTS "channel" (
	"channelid"	int NOT NULL,
	"channelname"	text NOT NULL,
	"description"	text,
	PRIMARY KEY("channelid")
);
CREATE UNIQUE INDEX IF NOT EXISTS "uq_servicename" ON "service" (
	"servicename"
);
CREATE UNIQUE INDEX IF NOT EXISTS "uq_output" ON "iodefine" (
	"output"
);
CREATE UNIQUE INDEX IF NOT EXISTS "uq_input" ON "iodefine" (
	"input"
);
CREATE UNIQUE INDEX IF NOT EXISTS "uq_tagname" ON "ioconfig" (
	"tagname"
);
CREATE UNIQUE INDEX IF NOT EXISTS "uq_channelname" ON "channel" (
	"channelname"
);
COMMIT;
