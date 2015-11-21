using FAQ_Web_Api_Angular.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FAQ_Web_Api_Angular
{
    public class FaqDB
    {
        public List<Faqs> getAllFaqs() // henter alle FAQs i databasen
        {

            using (var db = new FaqContext())
            {
                try
                {
                    List<Faqs> allFaqs = db.Faqs.Select(f => new Faqs()
                    {
                        id = f.id,
                        category = f.category,
                        question = f.question,
                        answer = f.answer,
                        top = f.top
                    }).ToList();
                    return allFaqs;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        public bool voteUp(int id) //metode som øker ratingen til en Faq.
        {
            using( var db = new FaqContext())
            {
                try
                {
                    var faqUp = (from f in db.Faqs where id == f.id select f).FirstOrDefault();
                    faqUp.top += 1;
                    db.SaveChanges();

                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }


        public List<QuestionModel> getAllQuestions() // Henter alle spørsmål i databasen.
        {
            using( var db = new FaqContext())
            {
                try
                {
                    List<QuestionModel> allQuestions = db.Questions.Select(q => new QuestionModel()
                    {
                        id = q.id,

                        title = q.title,
                        question = q.question,
                        email = q.email,
                        name = q.name

                    }).ToList();

                    return allQuestions;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }



        public bool saveQuestion(Question inQuestion) // legger til innkommdnde spøsmål i databasen
        {
            if (inQuestion != null)
            {
                var newQuestion = new Question
                {
                    title = inQuestion.title,
                    question = inQuestion.question,
                    email = inQuestion.email,
                    name = inQuestion.name
                };
                using (var db = new FaqContext())
                {
                    try
                    {
                        db.Questions.Add(newQuestion);
                        db.SaveChanges();
                        return true;

                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }

            }
            return false;
        }

        public bool deleteQuestion(int id) // sletter spørsmål fra databasen
        {

            using (var db = new FaqContext())
            {
                try
                {
                    var delQuestion = db.Questions.Find(id);
                    db.Questions.Remove(delQuestion);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        


    }
}