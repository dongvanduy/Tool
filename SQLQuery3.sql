USE [duy_ne]
GO
/****** Object:  StoredProcedure [dbo].[sp_account_login]    Script Date: 9/20/2024 4:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_account_login]
    @Username VARCHAR(50),
    @Password VARCHAR(50)
AS
BEGIN
    DECLARE @hashedPassword VARBINARY(64)
    DECLARE @res BIT

    -- Mã hóa mật khẩu người dùng nhập vào
    SET @hashedPassword = HASHBYTES('SHA2_256', @Password)

    -- Kiểm tra username và mật khẩu mã hóa
    IF EXISTS (
        SELECT 1 
        FROM account 
        WHERE Username = @Username 
        AND Password = @hashedPassword
    )
    BEGIN
        SET @res = 1 -- Đăng nhập thành công
    END
    ELSE
    BEGIN
        SET @res = 0 -- Đăng nhập thất bại
    END

    -- Trả về kết quả
    SELECT @res AS LoginResult
END