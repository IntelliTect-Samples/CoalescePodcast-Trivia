import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface AnswerViewModel extends $models.Answer {
  answerId: string | null;
  text: string | null;
  questionId: string | null;
  question: QuestionViewModel | null;
}
export class AnswerViewModel extends ViewModel<$models.Answer, $apiClients.AnswerApiClient, string> implements $models.Answer  {
  
  constructor(initialData?: DeepPartial<$models.Answer> | null) {
    super($metadata.Answer, new $apiClients.AnswerApiClient(), initialData)
  }
}
defineProps(AnswerViewModel, $metadata.Answer)

export class AnswerListViewModel extends ListViewModel<$models.Answer, $apiClients.AnswerApiClient, AnswerViewModel> {
  
  constructor() {
    super($metadata.Answer, new $apiClients.AnswerApiClient())
  }
}


export interface QuestionViewModel extends $models.Question {
  questionId: string | null;
  text: string | null;
  correctAnswerId: string | null;
  correctAnswer: AnswerViewModel | null;
  answers: AnswerViewModel[] | null;
}
export class QuestionViewModel extends ViewModel<$models.Question, $apiClients.QuestionApiClient, string> implements $models.Question  {
  
  
  public addToAnswers(initialData?: DeepPartial<$models.Answer> | null) {
    return this.$addChild('answers', initialData) as AnswerViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.Question> | null) {
    super($metadata.Question, new $apiClients.QuestionApiClient(), initialData)
  }
}
defineProps(QuestionViewModel, $metadata.Question)

export class QuestionListViewModel extends ListViewModel<$models.Question, $apiClients.QuestionApiClient, QuestionViewModel> {
  
  constructor() {
    super($metadata.Question, new $apiClients.QuestionApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  Answer: AnswerViewModel,
  Question: QuestionViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  Answer: AnswerListViewModel,
  Question: QuestionListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
}

