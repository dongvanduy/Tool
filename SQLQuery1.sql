






--Tạo stored procedure để thêm tài khoản với mật khẩu mã hóa
CREATE PROCEDURE sp_add_account
    @Username VARCHAR(50),
    @Password VARCHAR(50)
AS
BEGIN
    DECLARE @hashedPassword VARBINARY(64)

    -- Mã hóa mật khẩu người dùng nhập vào bằng SHA-256
    SET @hashedPassword = HASHBYTES('SHA2_256', @Password)

    -- Lưu Username, mật khẩu đã mã hóa và Email vào bảng account
    INSERT INTO account (Username, Password)
    VALUES (@Username, @hashedPassword)
END



--Kiểm tra đăng nhập với mật khẩu mã hóa
CREATE PROCEDURE sp_account_login
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




