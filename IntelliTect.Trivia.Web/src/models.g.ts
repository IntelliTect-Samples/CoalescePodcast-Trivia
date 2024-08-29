import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel, reactiveDataSource } from 'coalesce-vue/lib/model'

export enum AuditEntryState {
  EntityAdded = 0,
  EntityDeleted = 1,
  EntityModified = 2,
}


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


export interface AppUser extends Model<typeof metadata.AppUser> {
  id: string | null
  userName: string | null
  normalizedUserName: string | null
  email: string | null
  normalizedEmail: string | null
  emailConfirmed: boolean | null
  passwordHash: string | null
  securityStamp: string | null
  concurrencyStamp: string | null
  phoneNumber: string | null
  phoneNumberConfirmed: boolean | null
  twoFactorEnabled: boolean | null
  lockoutEnd: Date | null
  lockoutEnabled: boolean | null
  accessFailedCount: number | null
}
export class AppUser {
  
  /** Mutates the input object and its descendents into a valid AppUser implementation. */
  static convert(data?: Partial<AppUser>): AppUser {
    return convertToModel(data || {}, metadata.AppUser) 
  }
  
  /** Maps the input object and its descendents to a new, valid AppUser implementation. */
  static map(data?: Partial<AppUser>): AppUser {
    return mapToModel(data || {}, metadata.AppUser) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.AppUser; }
  
  /** Instantiate a new AppUser, optionally basing it on the given data. */
  constructor(data?: Partial<AppUser> | {[k: string]: any}) {
    Object.assign(this, AppUser.map(data || {}));
  }
}


export interface AuditLog extends Model<typeof metadata.AuditLog> {
  id: number | null
  type: string | null
  keyValue: string | null
  description: string | null
  state: AuditEntryState | null
  date: Date | null
  properties: AuditLogProperty[] | null
  clientIp: string | null
  referrer: string | null
  endpoint: string | null
}
export class AuditLog {
  
  /** Mutates the input object and its descendents into a valid AuditLog implementation. */
  static convert(data?: Partial<AuditLog>): AuditLog {
    return convertToModel(data || {}, metadata.AuditLog) 
  }
  
  /** Maps the input object and its descendents to a new, valid AuditLog implementation. */
  static map(data?: Partial<AuditLog>): AuditLog {
    return mapToModel(data || {}, metadata.AuditLog) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.AuditLog; }
  
  /** Instantiate a new AuditLog, optionally basing it on the given data. */
  constructor(data?: Partial<AuditLog> | {[k: string]: any}) {
    Object.assign(this, AuditLog.map(data || {}));
  }
}


export interface AuditLogProperty extends Model<typeof metadata.AuditLogProperty> {
  id: number | null
  parentId: number | null
  propertyName: string | null
  oldValue: string | null
  oldValueDescription: string | null
  newValue: string | null
  newValueDescription: string | null
}
export class AuditLogProperty {
  
  /** Mutates the input object and its descendents into a valid AuditLogProperty implementation. */
  static convert(data?: Partial<AuditLogProperty>): AuditLogProperty {
    return convertToModel(data || {}, metadata.AuditLogProperty) 
  }
  
  /** Maps the input object and its descendents to a new, valid AuditLogProperty implementation. */
  static map(data?: Partial<AuditLogProperty>): AuditLogProperty {
    return mapToModel(data || {}, metadata.AuditLogProperty) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.AuditLogProperty; }
  
  /** Instantiate a new AuditLogProperty, optionally basing it on the given data. */
  constructor(data?: Partial<AuditLogProperty> | {[k: string]: any}) {
    Object.assign(this, AuditLogProperty.map(data || {}));
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


export interface PublicAnswerDto extends Model<typeof metadata.PublicAnswerDto> {
  answerId: string | null
  text: string | null
}
export class PublicAnswerDto {
  
  /** Mutates the input object and its descendents into a valid PublicAnswerDto implementation. */
  static convert(data?: Partial<PublicAnswerDto>): PublicAnswerDto {
    return convertToModel(data || {}, metadata.PublicAnswerDto) 
  }
  
  /** Maps the input object and its descendents to a new, valid PublicAnswerDto implementation. */
  static map(data?: Partial<PublicAnswerDto>): PublicAnswerDto {
    return mapToModel(data || {}, metadata.PublicAnswerDto) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.PublicAnswerDto; }
  
  /** Instantiate a new PublicAnswerDto, optionally basing it on the given data. */
  constructor(data?: Partial<PublicAnswerDto> | {[k: string]: any}) {
    Object.assign(this, PublicAnswerDto.map(data || {}));
  }
}


export interface PublicQuestionDto extends Model<typeof metadata.PublicQuestionDto> {
  questionId: string | null
  text: string | null
  answers: PublicAnswerDto[] | null
}
export class PublicQuestionDto {
  
  /** Mutates the input object and its descendents into a valid PublicQuestionDto implementation. */
  static convert(data?: Partial<PublicQuestionDto>): PublicQuestionDto {
    return convertToModel(data || {}, metadata.PublicQuestionDto) 
  }
  
  /** Maps the input object and its descendents to a new, valid PublicQuestionDto implementation. */
  static map(data?: Partial<PublicQuestionDto>): PublicQuestionDto {
    return mapToModel(data || {}, metadata.PublicQuestionDto) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.PublicQuestionDto; }
  
  /** Instantiate a new PublicQuestionDto, optionally basing it on the given data. */
  constructor(data?: Partial<PublicQuestionDto> | {[k: string]: any}) {
    Object.assign(this, PublicQuestionDto.map(data || {}));
  }
}


