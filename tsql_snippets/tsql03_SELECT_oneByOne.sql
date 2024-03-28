DECLARE @now datetime    
SET     @now = GetDate() 


DECLARE @ID       bigint        
      , @Lagerort nvarchar(4000)

----  *************************************
BEGIN TRANSACTION

SELECT TOP(1)                  
       @ID = ID                
     , @Lagerort = Lagerort    
FROM   dbo.Table01_toAustria   
WHERE  message_toASB IS NULL   
ORDER  by ID                   

select @ID, @Lagerort --> ID + "single Value"

--UPDATE 
UPDATE dbo.Table01_toAustria   
   SET message_toASB = @now    
 WHERE ID = @ID

COMMIT
----  *************************************

---- check "the whole table"
SELECT *
FROM   dbo.Table01_toAustria

----  end  ----
