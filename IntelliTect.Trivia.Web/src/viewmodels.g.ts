import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ViewModelCollection, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface AnswerViewModel extends $models.Answer {
  answerId: string | null;
  text: string | null;
  questionId: string | null;
  get question(): QuestionViewModel | null;
  set question(value: QuestionViewModel | $models.Question | null);
}
export class AnswerViewModel extends ViewModel<$models.Answer, $apiClients.AnswerApiClient, string> implements $models.Answer  {
  static DataSources = $models.Answer.DataSources;
  
  constructor(initialData?: DeepPartial<$models.Answer> | null) {
    super($metadata.Answer, new $apiClients.AnswerApiClient(), initialData)
  }
}
defineProps(AnswerViewModel, $metadata.Answer)

export class AnswerListViewModel extends ListViewModel<$models.Answer, $apiClients.AnswerApiClient, AnswerViewModel> {
  static DataSources = $models.Answer.DataSources;
  
  constructor() {
    super($metadata.Answer, new $apiClients.AnswerApiClient())
  }
}


export interface AppUserViewModel extends $models.AppUser {
  id: string | null;
  userName: string | null;
  normalizedUserName: string | null;
  email: string | null;
  normalizedEmail: string | null;
  emailConfirmed: boolean | null;
  passwordHash: string | null;
  securityStamp: string | null;
  concurrencyStamp: string | null;
  phoneNumber: string | null;
  phoneNumberConfirmed: boolean | null;
  twoFactorEnabled: boolean | null;
  lockoutEnd: Date | null;
  lockoutEnabled: boolean | null;
  accessFailedCount: number | null;
}
export class AppUserViewModel extends ViewModel<$models.AppUser, $apiClients.AppUserApiClient, string> implements $models.AppUser  {
  
  constructor(initialData?: DeepPartial<$models.AppUser> | null) {
    super($metadata.AppUser, new $apiClients.AppUserApiClient(), initialData)
  }
}
defineProps(AppUserViewModel, $metadata.AppUser)

export class AppUserListViewModel extends ListViewModel<$models.AppUser, $apiClients.AppUserApiClient, AppUserViewModel> {
  
  constructor() {
    super($metadata.AppUser, new $apiClients.AppUserApiClient())
  }
}


export interface AuditLogViewModel extends $models.AuditLog {
  id: number | null;
  type: string | null;
  keyValue: string | null;
  description: string | null;
  state: $models.AuditEntryState | null;
  date: Date | null;
  get properties(): ViewModelCollection<AuditLogPropertyViewModel, $models.AuditLogProperty>;
  set properties(value: (AuditLogPropertyViewModel | $models.AuditLogProperty)[] | null);
  clientIp: string | null;
  referrer: string | null;
  endpoint: string | null;
}
export class AuditLogViewModel extends ViewModel<$models.AuditLog, $apiClients.AuditLogApiClient, number> implements $models.AuditLog  {
  
  
  public addToProperties(initialData?: DeepPartial<$models.AuditLogProperty> | null) {
    return this.$addChild('properties', initialData) as AuditLogPropertyViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.AuditLog> | null) {
    super($metadata.AuditLog, new $apiClients.AuditLogApiClient(), initialData)
  }
}
defineProps(AuditLogViewModel, $metadata.AuditLog)

export class AuditLogListViewModel extends ListViewModel<$models.AuditLog, $apiClients.AuditLogApiClient, AuditLogViewModel> {
  
  constructor() {
    super($metadata.AuditLog, new $apiClients.AuditLogApiClient())
  }
}


export interface AuditLogPropertyViewModel extends $models.AuditLogProperty {
  id: number | null;
  parentId: number | null;
  propertyName: string | null;
  oldValue: string | null;
  oldValueDescription: string | null;
  newValue: string | null;
  newValueDescription: string | null;
}
export class AuditLogPropertyViewModel extends ViewModel<$models.AuditLogProperty, $apiClients.AuditLogPropertyApiClient, number> implements $models.AuditLogProperty  {
  
  constructor(initialData?: DeepPartial<$models.AuditLogProperty> | null) {
    super($metadata.AuditLogProperty, new $apiClients.AuditLogPropertyApiClient(), initialData)
  }
}
defineProps(AuditLogPropertyViewModel, $metadata.AuditLogProperty)

export class AuditLogPropertyListViewModel extends ListViewModel<$models.AuditLogProperty, $apiClients.AuditLogPropertyApiClient, AuditLogPropertyViewModel> {
  
  constructor() {
    super($metadata.AuditLogProperty, new $apiClients.AuditLogPropertyApiClient())
  }
}


export interface QuestionViewModel extends $models.Question {
  questionId: string | null;
  text: string | null;
  category: $models.Category | null;
  correctAnswerId: string | null;
  get correctAnswer(): AnswerViewModel | null;
  set correctAnswer(value: AnswerViewModel | $models.Answer | null);
  get answers(): ViewModelCollection<AnswerViewModel, $models.Answer>;
  set answers(value: (AnswerViewModel | $models.Answer)[] | null);
}
export class QuestionViewModel extends ViewModel<$models.Question, $apiClients.QuestionApiClient, string> implements $models.Question  {
  static DataSources = $models.Question.DataSources;
  
  
  public addToAnswers(initialData?: DeepPartial<$models.Answer> | null) {
    return this.$addChild('answers', initialData) as AnswerViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.Question> | null) {
    super($metadata.Question, new $apiClients.QuestionApiClient(), initialData)
  }
}
defineProps(QuestionViewModel, $metadata.Question)

export class QuestionListViewModel extends ListViewModel<$models.Question, $apiClients.QuestionApiClient, QuestionViewModel> {
  static DataSources = $models.Question.DataSources;
  
  constructor() {
    super($metadata.Question, new $apiClients.QuestionApiClient())
  }
}


export class QuestionServiceViewModel extends ServiceViewModel<typeof $metadata.QuestionService, $apiClients.QuestionServiceApiClient> {
  
  public get getRandomQuestion() {
    const getRandomQuestion = this.$apiClient.$makeCaller(
      this.$metadata.methods.getRandomQuestion,
      (c) => c.getRandomQuestion(),
      () => ({}),
      (c, args) => c.getRandomQuestion())
    
    Object.defineProperty(this, 'getRandomQuestion', {value: getRandomQuestion});
    return getRandomQuestion
  }
  
  public get guessAnswer() {
    const guessAnswer = this.$apiClient.$makeCaller(
      this.$metadata.methods.guessAnswer,
      (c, answerId: string | null) => c.guessAnswer(answerId),
      () => ({answerId: null as string | null, }),
      (c, args) => c.guessAnswer(args.answerId))
    
    Object.defineProperty(this, 'guessAnswer', {value: guessAnswer});
    return guessAnswer
  }
  
  constructor() {
    super($metadata.QuestionService, new $apiClients.QuestionServiceApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  Answer: AnswerViewModel,
  AppUser: AppUserViewModel,
  AuditLog: AuditLogViewModel,
  AuditLogProperty: AuditLogPropertyViewModel,
  Question: QuestionViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  Answer: AnswerListViewModel,
  AppUser: AppUserListViewModel,
  AuditLog: AuditLogListViewModel,
  AuditLogProperty: AuditLogPropertyListViewModel,
  Question: QuestionListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
  QuestionService: QuestionServiceViewModel,
}

