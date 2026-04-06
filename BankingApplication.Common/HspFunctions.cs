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

    /*
     *CREATE FUNCTION hp.[fnGetARCClassConstant]
       (
           @ActionResultCode INT
       )
       RETURNS INT
       AS
       BEGIN
           RETURN (
               CASE
               WHEN @ActionResultCode BETWEEN 0 AND 99 THEN 0       -- Successful ARC Class
               WHEN @ActionResultCode BETWEEN 100 AND 399 THEN 100  -- General System ARC Class
               WHEN @ActionResultCode BETWEEN 400 AND 699 THEN 400  -- User/Customer ARC Class
               WHEN @ActionResultCode BETWEEN 700 AND 999 THEN 700  -- Reserved / N/A
               WHEN @ActionResultCode >= 1000 THEN 1000
               ELSE NULL END
           )
       END
     *
     */

    public static int? GetARCClassConstant(int actionResultCode)
    {
        if (actionResultCode >= 0 && actionResultCode <= 99)
            return 0;

        if (actionResultCode >= 100 && actionResultCode <= 399)
            return 100;

        if (actionResultCode >= 400 && actionResultCode <= 699)
            return 400;

        if (actionResultCode >= 700 && actionResultCode <= 999)
            return 700;

        if (actionResultCode >= 1000)
            return 1000;

        return null;
    }
}