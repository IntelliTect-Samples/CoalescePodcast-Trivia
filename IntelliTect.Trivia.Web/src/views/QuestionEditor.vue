<template>
  <v-container>
    <h1>Question Editor</h1>

    <c-loader-status :loaders="[question.$bulkSave]" />
    <c-loader-status no-initial-content :loaders="[question.$load]">
      <c-input :model="question" for="text" />
      <c-input
        :model="question"
        for="correctAnswer"
        :params="{ dataSource: answersForQuestionDataSource }"
      />
      <c-input :model="question" for="category" />

      <h3>Answers</h3>
      <div v-for="answer in question.answers" :key="answer.$stableId">
        <v-row dense>
          <v-col>
            <c-input :model="answer" for="text" />
          </v-col>
          <v-col cols="auto" align="right">
            <v-btn @click="answer.$delete()">Delete</v-btn>
          </v-col>
        </v-row>
      </div>

      <v-btn @click="addNewAnswer()" class="mr-2"> Add </v-btn>
      <v-btn
        @click="save"
        :disabled="question.$bulkSave.isLoading"
        :loading="question.$bulkSave.isLoading"
      >
        Save
      </v-btn>
    </c-loader-status>
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

function addNewAnswer() {
  question.addToAnswers();
}
</script>
