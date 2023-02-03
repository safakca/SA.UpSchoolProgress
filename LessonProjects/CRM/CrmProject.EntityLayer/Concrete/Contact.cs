﻿using System;

namespace CrmProject.EntityLayer.Concrete;
public class Contact
{
    public int ContactID { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
}
