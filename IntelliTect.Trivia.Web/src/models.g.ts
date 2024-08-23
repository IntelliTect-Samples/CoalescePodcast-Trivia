import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel, reactiveDataSource } from 'coalesce-vue/lib/model'

export enum Category {
  General = 0,
  Science = 1,
  History = 2,
  Geography = 3,
  Literature = 4,
  Technology = 5,
}


export interface Answer extends Model<typeof metadata.Answer> {
  answerId: string | null
  text: string | null
  questionId: string | null
  question: Question | null
}
export class Answer {
  
  /** Mutates the input object and its descendents into a valid Answer implementation. */
  static convert(data?: Partial<Answer>): Answer {
    return convertToModel(data || {}, metadata.Answer) 
  }
  
  /** Maps the input object and its descendents to a new, valid Answer implementation. */
  static map(data?: Partial<Answer>): Answer {
    return mapToModel(data || {}, metadata.Answer) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.Answer; }
  
  /** Instantiate a new Answer, optionally basing it on the given data. */
  constructor(data?: Partial<Answer> | {[k: string]: any}) {
    Object.assign(this, Answer.map(data || {}));
  }
}
export namespace Answer {
  export namespace DataSources {
    
    export class AnswersForQuestionDataSource implements DataSource<typeof metadata.Answer.dataSources.answersForQuestionDataSource> {
      readonly $metadata = metadata.Answer.dataSources.answersForQuestionDataSource
      questionId: string | null = null
      
      constructor(params?: Omit<Partial<AnswersForQuestionDataSource>, '$metadata'>) {
        if (params) Object.assign(this, params);
        return reactiveDataSource(this);
      }
    }
  }
}


export interface Question extends Model<typeof metadata.Question> {
  questionId: string | null
  text: string | null
  category: Category | null
  correctAnswerId: string | null
  correctAnswer: Answer | null
  answers: Answer[] | null
}
export class Question {
  
  /** Mutates the input object and its descendents into a valid Question implementation. */
  static convert(data?: Partial<Question>): Question {
    return convertToModel(data || {}, metadata.Question) 
  }
  
  /** Maps the input object and its descendents to a new, valid Question implementation. */
  static map(data?: Partial<Question>): Question {
    return mapToModel(data || {}, metadata.Question) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.Question; }
  
  /** Instantiate a new Question, optionally basing it on the given data. */
  constructor(data?: Partial<Question> | {[k: string]: any}) {
    Object.assign(this, Question.map(data || {}));
  }
}
export namespace Question {
  export namespace DataSources {
    
    export class QuestionsDataSource implements DataSource<typeof metadata.Question.dataSources.questionsDataSource> {
      readonly $metadata = metadata.Question.dataSources.questionsDataSource
      correctAnswerText: string | null = null
      
      constructor(params?: Omit<Partial<QuestionsDataSource>, '$metadata'>) {
        if (params) Object.assign(this, params);
        return reactiveDataSource(this);
      }
    }
  }
}


