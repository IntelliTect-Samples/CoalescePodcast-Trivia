<template>
  <v-container>
    <h1>Question Editor</h1>

    <c-input :model="question" for="text" />
    <c-input
      :model="question"
      for="correctAnswer"
      :params="{ dataSource: answersForQuestionDataSource }"
    />

    <h3>Answers</h3>
    <div v-for="answer in question.answers" :key="answer.$stableId">
      <c-input :model="answer" for="text" />
    </div>

    <v-btn @click="save"> Save </v-btn>
  </v-container>
</template>

<script setup lang="ts">
import { Answer } from "@/models.g";
import { QuestionViewModel } from "@/viewmodels.g";

const props = defineProps<{
  id: string;
}>();

const question = new QuestionViewModel();
question.$load(props.id);

question.$useAutoSave({ deep: true });

const answersForQuestionDataSource =
  new Answer.DataSources.AnswersForQuestionDataSource();
answersForQuestionDataSource.questionId = props.id;

function save() {
  question.$bulkSave();
}
</script>
