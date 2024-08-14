import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosPromise, AxiosRequestConfig, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'

export class AnswerApiClient extends ModelApiClient<$models.Answer> {
  constructor() { super($metadata.Answer) }
}


export class QuestionApiClient extends ModelApiClient<$models.Question> {
  constructor() { super($metadata.Question) }
}


export class QuestionServiceApiClient extends ServiceApiClient<typeof $metadata.QuestionService> {
  constructor() { super($metadata.QuestionService) }
  public getRandomQuestion($config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.Question>> {
    const $method = this.$metadata.methods.getRandomQuestion
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
}


