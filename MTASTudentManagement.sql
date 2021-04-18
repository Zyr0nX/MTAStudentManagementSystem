CREATE DATABASE MTASTudentManagement
GO

USE MTASTudentManagement
GO

CREATE TABLE dbo.LOP
(
    MAL VARCHAR(10),
	TENL NVARCHAR(50),
	PRIMARY KEY (MAL)
)
GO

CREATE TABLE dbo.SINHVIEN
(
    MASV VARCHAR(10),
	TENSV NVARCHAR(50),
	NGAYSINHSV DATE,
	SOCMNDSV VARCHAR(12),
	MAL VARCHAR(10) REFERENCES dbo.LOP(MAL),
	CHECK (SOCMNDSV NOT LIKE '%[^0-9]%'),
	PRIMARY KEY (MASV),
)
GO

CREATE TABLE dbo.GIANGDUONG
(
    MAGD VARCHAR(10),
	MOTAGD NVARCHAR(50),
	PRIMARY KEY (MAGD)
)
GO

CREATE TABLE dbo.HOCPHAN
(
	MAHP VARCHAR(10),
	TENHP NVARCHAR(50),
	SOTC TINYINT,
	GIANGVIEN NVARCHAR(100) REFERENCES dbo.GIANGDUONG(MAGD),
	THU VARCHAR(10),
	TIET VARCHAR(10),
	MAGD VARCHAR(10),
	PRIMARY KEY (MAHP)
)
GO

CREATE TABLE dbo.PHIEUDIEM
(
    MAPD VARCHAR(10),
	DIEMCC DECIMAL(3,1),
	DIEMTX DECIMAL(3,1),
	DIEMT DECIMAL(3,1),
	DIEMTB DECIMAL(3,1),
	PRIMARY KEY (MAPD)
)
GO

CREATE TABLE dbo.DANGKYHOCPHAN
(
    MASV VARCHAR(10) REFERENCES dbo.SINHVIEN(MASV),
	MAHP VARCHAR(10) REFERENCES dbo.HOCPHAN(MAHP),
	MAPD VARCHAR(10) REFERENCES dbo.PHIEUDIEM(MAPD),
	PRIMARY KEY (MASV, MAHP),
)