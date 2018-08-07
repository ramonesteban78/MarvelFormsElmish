module MarvelTypes

type MarvelData<'a> = 
    {
        offset : int
        limit : int
        total : int
        count : int
        results : 'a list
    }

type MarvelApiResult<'a> =
    {
        code : string
        status : string
        copyright : string
        attributionText : string
        attributionHTML : string
        etag : string
        data : MarvelData<'a>
    }