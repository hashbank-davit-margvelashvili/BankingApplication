namespace BankingApplication.Common;

/*
    -- Source: HSP/hp/Functions/fnGetErrorNumberConstant.sql
    CREATE FUNCTION hp.[fnGetErrorNumberConstant]
    (
        @Type VARCHAR(50) = 'UserErrorClass60000'
    )
    RETURNS INT
    AS
        BEGIN
    RETURN(
        CASE
    WHEN @Type = 'UserErrorClass60000' THEN 60000
    WHEN @Type = 'SysErrorClass60001' THEN 60001
    WHEN @Type = 'ARC_GeneralError101' THEN 101
    ELSE 60000 END
        )
    END
*/

public static class HspFunctions
{
    public static int GetErrorNumberConstant(string type = "UserErrorClass60000")
    {
        switch (type)
        {
            case "UserErrorClass60000":
                return 60000;

            case "SysErrorClass60001":
                return 60001;

            case "ARC_GeneralError101":
                return 101;

            default:
                return 60000;
        }
    }
}