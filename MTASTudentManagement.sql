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
	MAL VARCHAR(10) REFERENCES dbo.LOP(MAL) ON DELETE CASCADE ON UPDATE CASCADE,
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
	GIANGVIEN NVARCHAR(100),
	THU VARCHAR(10),
	TIET VARCHAR(10),
	MAGD VARCHAR(10) REFERENCES dbo.GIANGDUONG(MAGD) ON DELETE CASCADE ON UPDATE CASCADE,
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
    MASV VARCHAR(10) REFERENCES dbo.SINHVIEN(MASV) ON DELETE CASCADE ON UPDATE CASCADE,
	MAHP VARCHAR(10) REFERENCES dbo.HOCPHAN(MAHP) ON DELETE CASCADE ON UPDATE CASCADE,
	MAPD VARCHAR(10) REFERENCES dbo.PHIEUDIEM(MAPD) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY (MASV, MAHP),
)
GO

SELECT [dbo].[TAOMAL]()

CREATE FUNCTION [dbo].[TAOMAL]()
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @MAL VARCHAR(10)
DECLARE @MAXMAL VARCHAR(10)
DECLARE @MAX INT
SELECT @MAXMAL = MAX(MAL) FROM dbo.LOP
IF EXISTS (SELECT @MAL FROM dbo.LOP)
	SET @MAX = CONVERT(INT, SUBSTRING(@MAXMAL, 2 ,4))
ELSE SET @MAX = 0
IF (@MAX < 10) SET @MAL = 'L000' + CONVERT (VARCHAR(1), @MAX + 1)
ELSE
IF (@MAX < 100) SET @MAL = 'L00' + CONVERT (VARCHAR(2), @MAX + 1)
ELSE
IF (@MAX < 1000) SET @MAL = 'L0' + CONVERT (VARCHAR(3), @MAX + 1)
RETURN @MAL
END
GO	

CREATE PROC [dbo].[ThemSuaL]
@mal VARCHAR(10), @tenl NVARCHAR(50)
AS
BEGIN
	DECLARE @tontai INT
	SELECT @tontai = COUNT(*)
	FROM dbo.LOP
	WHERE MAL = @mal
	IF (@tontai = 0)
	BEGIN
		INSERT INTO dbo.LOP
		(
		    MAL,
		    TENL
		)
		VALUES
		(   @mal, -- MAL - varchar(10)
		    @tenl -- TENL - nvarchar(50)
		    )
	END
	ELSE IF (@tontai > 0)
	BEGIN
		UPDATE dbo.LOP
		SET TENL = @tenl
		WHERE MAL = @mal
	END
END

CREATE PROC dbo.XoaLop
@mal VARCHAR(10)
AS
BEGIN
	DELETE FROM dbo.LOP WHERE MAL = @mal
END

CREATE FUNCTION [dbo].[TAOMASV]()
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @MASV VARCHAR(10)
DECLARE @MAXMASV VARCHAR(10)
DECLARE @MAX INT
SELECT @MAXMASV = MAX(MASV) FROM dbo.SINHVIEN
IF EXISTS (SELECT @MASV FROM dbo.SINHVIEN)
	SET @MAX = CONVERT(INT, SUBSTRING(@MAXMASV, 3 ,4))
ELSE SET @MAX = 0
IF (@MAX < 10) SET @MASV = 'SV000' + CONVERT (VARCHAR(1), @MAX + 1)
ELSE
IF (@MAX < 100) SET @MASV = 'SV00' + CONVERT (VARCHAR(2), @MAX + 1)
ELSE
IF (@MAX < 1000) SET @MASV = 'SV0' + CONVERT (VARCHAR(3), @MAX + 1)
RETURN @MASV
END
GO

CREATE PROC [dbo].[ThemSuaSV]
@masv VARCHAR(10), @tensv NVARCHAR(50), @ngaysinhsv DATE, @socmndsv VARCHAR(12), @mal VARCHAR(10)
AS
BEGIN
	DECLARE @tontai INT
	SELECT @tontai = COUNT(*)
	FROM dbo.SINHVIEN
	WHERE MASV = @masv
	IF (@tontai = 0)
	BEGIN
		INSERT INTO dbo.SINHVIEN
		(
		    MASV,
		    TENSV,
		    NGAYSINHSV,
		    SOCMNDSV,
		    MAL
		)
		VALUES
		(   @masv,        -- MASV - varchar(10)
		    @tensv,       -- TENSV - nvarchar(50)
		    @ngaysinhsv, -- NGAYSINHSV - date
		    @socmndsv,        -- SOCMNDSV - varchar(12)
		    @mal         -- MAL - varchar(10)
		    )
	END
	ELSE IF (@tontai > 0)
	BEGIN
		UPDATE dbo.SINHVIEN
		SET TENSV = @tensv, NGAYSINHSV=@ngaysinhsv, SOCMNDSV=@socmndsv, MAL = @mal
		WHERE MASV = @masv
	END
END

CREATE PROC dbo.XoaSinhVien
@masv VARCHAR(10)
AS
BEGIN
	DELETE FROM dbo.SINHVIEN WHERE MASV = @masv
END
GO

CREATE PROC dbo.TimKiemLop
@mal VARCHAR(10), @tenl VARCHAR(50)
AS
BEGIN
    SELECT * FROM dbo.LOP WHERE(MAL LIKE '%' + @mal + '%' OR MAL = '') AND (TENL LIKE N'%' + @tenl + N'%' OR TENL = '')
END
GO

CREATE FUNCTION dbo.GetTenLopByMaLop(@mal VARCHAR(10))
RETURNS VARCHAR(50)
AS
BEGIN
    DECLARE @tenl VARCHAR(50)
	SELECT @tenl=TENL FROM dbo.LOP WHERE MAL=@mal
	RETURN @tenl
END
GO

CREATE PROC dbo.GetDanhSachLop
@mal AS VARCHAR(10), @tenl AS VARCHAR(50)
AS
BEGIN
    SELECT MASV, TENSV, NGAYSINHSV, SOCMNDSV, TENL
	FROM dbo.SINHVIEN INNER JOIN dbo.LOP
	ON (dbo.SINHVIEN.MAL = dbo.LOP.MAL)
	WHERE (dbo.LOP.MAL LIKE '%' + @mal + '%' OR dbo.LOP.MAL = '') AND (dbo.LOP.TENL LIKE '%' + @tenl + '%')
END
GO

CREATE FUNCTION [dbo].[TAOMAGD]()
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @MAGD VARCHAR(10)
DECLARE @MAXMAGD VARCHAR(10)
DECLARE @MAX INT
SELECT @MAXMAGD = MAX(MAGD) FROM dbo.GIANGDUONG
IF EXISTS (SELECT @MAGD FROM dbo.GIANGDUONG)
	SET @MAX = CONVERT(INT, SUBSTRING(@MAXMAGD, 3 ,4))
ELSE SET @MAX = 0
IF (@MAX < 10) SET @MAGD = 'GD000' + CONVERT (VARCHAR(1), @MAX + 1)
ELSE
IF (@MAX < 100) SET @MAGD = 'GD00' + CONVERT (VARCHAR(2), @MAX + 1)
ELSE
IF (@MAX < 1000) SET @MAGD = 'GD0' + CONVERT (VARCHAR(3), @MAX + 1)
RETURN @MAGD
END
GO

CREATE PROC [dbo].[ThemSuaGD]
@magd VARCHAR(10), @motagd NVARCHAR(50)
AS
BEGIN
	DECLARE @tontai INT
	SELECT @tontai = COUNT(*)
	FROM dbo.GIANGDUONG
	WHERE MAGD = @magd
	IF (@tontai = 0)
	BEGIN
		INSERT INTO dbo.GIANGDUONG
		(
		    MAGD,
		    MOTAGD
		)
		VALUES
		(   @magd, -- MAGD - varchar(10)
		    @motagd -- MOTAGD - nvarchar(50)
		    )
	END
	ELSE IF (@tontai > 0)
	BEGIN
		UPDATE dbo.GIANGDUONG
		SET MOTAGD = @motagd
		WHERE MAGD = @magd
	END
END

CREATE PROC dbo.XoaGiangDuong
@magd VARCHAR(10)
AS
BEGIN
	DELETE FROM dbo.GIANGDUONG WHERE MAGD = @magd
END
GO

CREATE PROC dbo.TimKiemGiangDuong
@magd VARCHAR(10), @motagd VARCHAR(50)
AS
BEGIN
    SELECT * FROM dbo.GIANGDUONG WHERE(MAGD LIKE '%' + @magd + '%' OR MAGD = '') AND (MOTAGD LIKE '%' + @motagd + '%' OR MOTAGD = '')
END
GO

CREATE PROC [dbo].[ThemSuaHP]
@mahp VARCHAR(10), @tenhp NVARCHAR(50), @sotc TINYINT, @giangvien NVARCHAR(100), @thu NVARCHAR(10), @tiet NVARCHAR(10), @magd NVARCHAR(10)
AS
BEGIN
	DECLARE @tontai INT
	SELECT @tontai = COUNT(*)
	FROM dbo.HOCPHAN
	WHERE MAHP = @mahp
	IF (@tontai = 0)
	BEGIN
		INSERT INTO dbo.HOCPHAN
		(
		    MAHP,
		    TENHP,
		    SOTC,
		    GIANGVIEN,
		    THU,
		    TIET,
		    MAGD
		)
		VALUES
		(   @mahp,  -- MAHP - varchar(10)
		    @tenhp, -- TENHP - nvarchar(50)
		    @sotc,   -- SOTC - tinyint
		    @giangvien, -- GIANGVIEN - nvarchar(100)
		    @thu,  -- THU - varchar(10)
		    @tiet,  -- TIET - varchar(10)
		    @magd   -- MAGD - varchar(10)
		    )
	END
	ELSE IF (@tontai > 0)
	BEGIN
		UPDATE dbo.HOCPHAN
		SET TENHP = @tenhp, SOTC=@sotc, GIANGVIEN=@giangvien, THU = @thu, TIET=@tiet, MAGD=@magd
		WHERE MAHP = @mahp
	END
END
GO

CREATE PROC dbo.XoaHocPhan
@mahp VARCHAR(10)
AS
BEGIN
	DELETE FROM dbo.HOCPHAN WHERE MAHP = @mahp
END
GO

CREATE FUNCTION [dbo].[TAOMAHP]()
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @MAHP VARCHAR(10)
DECLARE @MAXMAHP VARCHAR(10)
DECLARE @MAX INT
SELECT @MAXMAHP = MAX(MAHP) FROM dbo.HOCPHAN
IF EXISTS (SELECT @MAHP FROM dbo.HOCPHAN)
	SET @MAX = CONVERT(INT, SUBSTRING(@MAXMAHP, 3 ,4))
ELSE SET @MAX = 0
IF (@MAX < 10) SET @MAHP = 'HP000' + CONVERT (VARCHAR(1), @MAX + 1)
ELSE
IF (@MAX < 100) SET @MAHP = 'HP00' + CONVERT (VARCHAR(2), @MAX + 1)
ELSE
IF (@MAX < 1000) SET @MAHP = 'HPD0' + CONVERT (VARCHAR(3), @MAX + 1)
RETURN @MAHP
END
GO

CREATE PROC dbo.TimKiemHocPhan
@mahp VARCHAR(10), @tenhp VARCHAR(50)
AS
BEGIN
    SELECT * FROM dbo.HOCPHAN WHERE(MAHP LIKE '%' + @mahp + '%' OR MAHP = '') AND (TENHP LIKE '%' + @tenhp + '%' OR TENHP = '')
END
GO

CREATE FUNCTION [dbo].[TAOMAPD]()
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @MAPD VARCHAR(10)
DECLARE @MAXMAPD VARCHAR(10)
DECLARE @MAX INT
SELECT @MAXMAPD = MAX(MAPD) FROM dbo.PHIEUDIEM
IF EXISTS (SELECT @MAPD FROM dbo.PHIEUDIEM)
	SET @MAX = CONVERT(INT, SUBSTRING(@MAXMAPD, 3 ,4))
ELSE SET @MAX = 0
IF (@MAX < 10) SET @MAPD = 'PD000' + CONVERT (VARCHAR(1), @MAX + 1)
ELSE
IF (@MAX < 100) SET @MAPD = 'PD00' + CONVERT (VARCHAR(2), @MAX + 1)
ELSE
IF (@MAX < 1000) SET @MAPD = 'PDD0' + CONVERT (VARCHAR(3), @MAX + 1)
RETURN @MAPD
END
GO

CREATE TRIGGER dbo.TriggerTaoMaPhieuDiem ON dbo.DANGKYHOCPHAN
AFTER INSERT
AS
BEGIN
	DECLARE @mapd VARCHAR(10)
	SET @mapd = dbo.TAOMAPD()
    INSERT INTO dbo.PHIEUDIEM
    (
        MAPD,
        DIEMCC,
        DIEMTX,
        DIEMT,
        DIEMTB
    )
    VALUES
    (   @mapd,   -- MAPD - varchar(10)
        NULL, -- DIEMCC - decimal(3, 1)
        NULL, -- DIEMTX - decimal(3, 1)
        NULL, -- DIEMT - decimal(3, 1)
        NULL  -- DIEMTB - decimal(3, 1)
        )
	UPDATE dbo.DANGKYHOCPHAN SET MAPD = @mapd FROM Inserted WHERE dbo.DANGKYHOCPHAN.MASV = Inserted.MASV AND dbo.DANGKYHOCPHAN.MAHP = Inserted.MAHP
END
GO

CREATE PROC dbo.ThemHocPhanDangKy
@masv VARCHAR(10), @mahp VARCHAR(10)
AS
BEGIN
    INSERT INTO dbo.DANGKYHOCPHAN
    (
        MASV,
        MAHP,
        MAPD
    )
    VALUES
    (   @masv, -- MASV - varchar(10)
        @mahp, -- MAHP - varchar(10)
        NULL  -- MAPD - varchar(10)
        )
END
GO

CREATE PROC dbo.XoaHocPhanDangKy
@masv VARCHAR(10), @mahp VARCHAR(10)
AS
BEGIN
	DELETE FROM dbo.DANGKYHOCPHAN WHERE MASV = @masv AND MAHP = @mahp
END
GO