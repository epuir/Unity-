using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public class Book:ISerializable,IDeserializationCallback
{
    public string Title { get; set; }
    public string Author{ get; set; }
    public string ISBN{ get; set; }
    
    public Book(){}

  
    protected Book(SerializationInfo info, StreamingContext context)
    {
        Title = info.GetString("Title");
        Author = info.GetString("Author");
        ISBN = info.GetString("ISBN");
    }
    
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        if (info == null)
            throw new ArgumentNullException(nameof(info));
        info.AddValue("Title",Title);
        info.AddValue("Author",Author);
        info.AddValue("ISBN",ISBN);
    }

    //实现IDeserializationCallback接口
    public void OnDeserialization(object sender)
    {
        //反序列化后执行
    }
}